using BookVerse.Application.Dtos.Payment;
using BookVerse.Application.Interfaces;
using BookVerse.Core.Constants;
using BookVerse.Core.Enums;
using BookVerse.Core.Exceptions;
using BookVerse.Core.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Stripe;

namespace BookVerse.Infrastructure.Services;

public class PaymentService : IPaymentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<PaymentService> _logger;
    private readonly IStripePaymentIntentService _paymentIntentService;
    private readonly IStripeWebhookConstructor _webhookConstructor;
    private readonly StripeOptions _stripeOptions;

    public PaymentService(IUnitOfWork unitOfWork, IOptions<StripeOptions> stripeOptions, ILogger<PaymentService> logger,
        IStripePaymentIntentService paymentIntentService, IStripeWebhookConstructor webhookConstructor)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _paymentIntentService = paymentIntentService;
        _webhookConstructor = webhookConstructor;
        _stripeOptions = stripeOptions.Value;
    }

    public async Task<PaymentIntentResponseDto> CreatePaymentIntentAsync(int orderId, Guid userId,
        CancellationToken cancellationToken = default)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(orderId, cancellationToken);
        if (order == null)
            throw new NotFoundException(ErrorMessages.OrderNotFound);

        if (order.UserId != userId)
        {
            throw new ForbiddenException(ErrorMessages.AccessDenied);
        }

        if (order.PaymentStatus != PaymentStatus.Pending)
        {
            throw new ValidationException(ErrorMessages.OrderNotInPendingPaymentStatus);
        }

        // Idempotency guard : if a PaymentIntent already exists for this order , return teh existing client secret instead of creating a second one.
        if (!string.IsNullOrEmpty(order.StripePaymentIntentId))
        {
            _logger.LogInformation(
                "PaymentIntent already exists for order {OrderId}: {PaymentIntentId} - attempting reuse",
                orderId,
                order.StripePaymentIntentId);

            try
            {
                var existingIntent = await _paymentIntentService.GetAsync(
                    order.StripePaymentIntentId,
                    cancellationToken: cancellationToken);

                return new PaymentIntentResponseDto
                {
                    ClientSecret = existingIntent.ClientSecret,
                    PublishableKey = _stripeOptions.PublishableKey,
                    OrderId = orderId,
                    Amount = order.TotalAmount
                };
            }
            catch (StripeException ex) when (ex.StripeError?.Code == "resource_missing")
            {
                _logger.LogWarning(
                    ex,
                    "PaymentIntent {Id} not found in Stripe for order {OrderId}. Creating a new one.",
                    order.StripePaymentIntentId,
                    orderId);

                // fall through → recreate intent
            }
            catch (StripeException ex)
            {
                _logger.LogError(ex, "Stripe error while retrieving PaymentIntent {Id} for order {OrderId}",
                    order.StripePaymentIntentId, orderId);
                throw new PaymentProcessingException(ErrorMessages.StripeRetrievalFailed);
            }
        }

        var request = new CreatePaymentIntentRequest(
            Amount: (long)(order.TotalAmount * 100),
            Currency: "aed",
            CustomerId: null,
            Metadata: new Dictionary<string, string>
            {
                { "orderId", orderId.ToString() },
                { "orderNumber", order.OrderNumber }
            }
        );

        var result = await _paymentIntentService.CreateAsync(request, cancellationToken);
        order.StripePaymentIntentId = result.Id;

        _unitOfWork.Orders.Update(order);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new PaymentIntentResponseDto
        {
            ClientSecret = result.ClientSecret,
            PublishableKey = _stripeOptions.PublishableKey,
            OrderId = orderId,
            Amount = order.TotalAmount
        };
    }

    public async Task HandleWebhookAsync(string json, string stripeSignature,
        CancellationToken cancellationToken = default)
    {
        ParsedStripeEvent parsedEvent;
        try
        {
            parsedEvent = _webhookConstructor.ConstructEvent(
                json, stripeSignature, _stripeOptions.WebhookSecret);
        }
        catch (StripeException ex)
        {
            _logger.LogWarning(ex, "Invalid Stripe webhook signature");
            throw new ValidationException(ErrorMessages.StripeWebhookSignatureInvalid);
        }

        if (parsedEvent.EventType == EventTypes.PaymentIntentSucceeded)
        {
            if (parsedEvent.PaymentIntentId == null)
            {
                _logger.LogWarning("PaymentIntentSucceeded event received but PaymentIntent object was null");
                return;
            }

            _logger.LogInformation("PaymentIntent succeeded: {PaymentIntentId}", parsedEvent.PaymentIntentId);

            var order = await _unitOfWork.Orders.GetByStripePaymentIntentIdAsync(parsedEvent.PaymentIntentId,
                cancellationToken);
            if (order == null)
            {
                _logger.LogWarning("No order found for PaymentIntent {PaymentIntentId}", parsedEvent.PaymentIntentId);
                return;
            }

            // Idempotency guard: if this event was already processed, treat as a no-op.
            // Stripe retries webhooks on non-2xx; without this guard, a retry would
            // re-fulfill an already-paid order.

            if (order.PaymentStatus == PaymentStatus.Completed)
            {
                _logger.LogInformation(
                    "Duplicate webhook ignored for already-completed order {OrderNumber}",
                    order.OrderNumber);
                return;
            }

            order.PaymentStatus = PaymentStatus.Completed;
            order.Status = OrderStatus.Processing;
            _unitOfWork.Orders.Update(order);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Order {OrderNumber} updated to Completed/Processing", order.OrderNumber);
        }
        else if (parsedEvent.EventType == EventTypes.PaymentIntentPaymentFailed)
        {
            await MarkOrderPaymentFailedAsync(parsedEvent, "PaymentIntentPaymentFailed", cancellationToken);
        }
        else if (parsedEvent.EventType == EventTypes.PaymentIntentCanceled)
        {
            // Stripe fires this when a PaymentIntent is explicitly cancelled, or automatically
            // when it times out (24h default) — e.g. the customer abandoned checkout partway through.
            //Either way the order can't be left sitting in Pending forever, so it's resolved the same way a failed payment is resolved.

            await MarkOrderPaymentFailedAsync(parsedEvent, "PaymentIntentCanceled", cancellationToken);
        }
        else
        {
            //Logging means an unexpected new Stripe
            // event type shows up in our logs instead of vanishing without a trace.
            _logger.LogInformation("Ignoring unhandled Stripe webhook event type: {EventType}",
                parsedEvent.EventType);
        }
    }

    private async Task MarkOrderPaymentFailedAsync(ParsedStripeEvent parsedEvent, string eventLabel,
        CancellationToken cancellationToken)
    {
        if (parsedEvent.PaymentIntentId == null)
        {
            _logger.LogWarning("{EventLabel} event received but PaymentIntent object was null", eventLabel);
            return;
        }

        var order = await _unitOfWork.Orders.GetByStripePaymentIntentIdAsync(parsedEvent.PaymentIntentId,
            cancellationToken);

        if (order == null)
        {
            _logger.LogWarning("No order found for PaymentIntent {PaymentIntentId}", parsedEvent.PaymentIntentId);

            return;
        }

        //Idempotency guard: already failed - nothing to do.
        if (order.PaymentStatus == PaymentStatus.Failed)
        {
            _logger.LogInformation(
                "Duplicate webhook ignored for already-failed order {OrderNumber}",
                order.OrderNumber);
            return;
        }

        // Secondary guard: CancelOrderAsync may have already cancelled this order (and restored stock) before this webhook fired. In that case, just mark the payment failed and exit  do NOT restore stock a second time.
        if (order.Status == OrderStatus.Cancelled)
        {
            order.PaymentStatus = PaymentStatus.Failed;
            _unitOfWork.Orders.Update(order);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            _logger.LogInformation(
                "Order {OrderNumber} was already cancelled — payment marked Failed without stock change",
                order.OrderNumber);
            return;
        }

        order.PaymentStatus = PaymentStatus.Failed;
        order.Status = OrderStatus.Cancelled;
        _unitOfWork.Orders.Update(order);

        // Restore stock. GetByStripePaymentIntentIdAsync does not Include(o => o.OrderItems),so we query them separately.

        var failedOrderItems = await _unitOfWork.OrderItems.FindAsync(oi => oi.OrderId == order.Id, cancellationToken);

        if (failedOrderItems.Count > 0)
        {
            var bookIds = failedOrderItems.Select(oi => oi.BookId).ToList();
            var books =
                (await _unitOfWork.Books.FindAsync(b => bookIds.Contains(b.Id), cancellationToken)).ToDictionary(b =>
                    b.Id);

            foreach (var item in failedOrderItems)
            {
                if (books.TryGetValue(item.BookId, out var book))
                {
                    book.QuantityInStock += item.Quantity;
                    _unitOfWork.Books.Update(book);
                }
            }
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("Order {OrderNumber} auto-cancelled and stock restored ({EventLabel})",
            order.OrderNumber, eventLabel);
    }
}
/*
 *             if (parsedEvent.PaymentIntentId == null)
            {
                _logger.LogWarning("PaymentIntentPaymentFailed event received but PaymentIntent object was null");
                return;
            }

            var order = await _unitOfWork.Orders.GetByStripePaymentIntentIdAsync(parsedEvent.PaymentIntentId,
                cancellationToken);
            if (order == null)
            {
                _logger.LogWarning("No order found for PaymentIntent {PaymentIntentId}", parsedEvent.PaymentIntentId);
                return;
            }

            // Idempotency guard: already failed — nothing to do.
            if (order.PaymentStatus == PaymentStatus.Failed)
            {
                _logger.LogInformation(
                    "Duplicate webhook ignored for already-failed order {OrderNumber}",
                    order.OrderNumber);
                return;
            }

            order.PaymentStatus = PaymentStatus.Failed;
            _unitOfWork.Orders.Update(order);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Order {OrderNumber} payment marked as Failed", order.OrderNumber);
 */