using BookVerse.Application.Dtos.Payment;
using BookVerse.Application.Interfaces;
using BookVerse.Core.Constants;
using BookVerse.Core.Enums;
using BookVerse.Core.Exceptions;
using BookVerse.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Stripe;

namespace BookVerse.Infrastructure.Services;

public class PaymentService : IPaymentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<PaymentService> _logger;
    private readonly StripeOptions _stripeOptions;

    public PaymentService(IUnitOfWork unitOfWork, IOptions<StripeOptions> stripeOptions,ILogger<PaymentService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
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
            throw new ForbiddenException(ErrorMessages.OrderNotFound);
        }

        if (order.PaymentStatus != PaymentStatus.Pending)
        {
            throw new ValidationException(ErrorMessages.OrderNotInPendingPaymentStatus);
        }

        var options = new PaymentIntentCreateOptions
        {
            Amount = (long)(order.TotalAmount * 100),
            Currency = "aed",
            Metadata = new Dictionary<string, string>
            {
                { "orderId", orderId.ToString() },
                { "orderNumber", order.OrderNumber }
            }
        };

        var service = new PaymentIntentService();
        var paymentIntent = await service.CreateAsync(options, cancellationToken: cancellationToken);

        order.StripePaymentIntentId = paymentIntent.Id;
        _unitOfWork.Orders.Update(order);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new PaymentIntentResponseDto
        {
            ClientSecret = paymentIntent.ClientSecret,
            PublishableKey = _stripeOptions.PublishableKey,
            OrderId = orderId,
            Amount = order.TotalAmount
        };
    }

    public async Task HandleWebhookAsync(string json, string stripeSignature,
        CancellationToken cancellationToken = default)
    {
        Event stripeEvent;
        try
        {
            stripeEvent = EventUtility.ConstructEvent(
                json, stripeSignature, _stripeOptions.WebhookSecret);
        }
        catch (StripeException ex)
        {
            _logger.LogWarning(ex, "Invalid Stripe webhook signature");
            throw new ValidationException(ErrorMessages.StripeWebhookSignatureInvalid);
        }

        if (stripeEvent.Type == EventTypes.PaymentIntentSucceeded)
        {
            var paymentIntent = stripeEvent.Data.Object as Stripe.PaymentIntent;
            if (paymentIntent == null)
            {
                _logger.LogWarning("PaymentIntentSucceeded event received but PaymentIntent object was null");
                return;
            }

            _logger.LogInformation("PaymentIntent succeeded: {PaymentIntentId}", paymentIntent.Id);

            var order = await _unitOfWork.Orders.GetByStripePaymentIntentIdAsync(paymentIntent.Id,
                cancellationToken);
            if (order == null)
            {
                _logger.LogWarning("No order found for PaymentIntent {PaymentIntentId}", paymentIntent.Id);
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
        else if (stripeEvent.Type == EventTypes.PaymentIntentPaymentFailed)
        {
            var paymentIntent = stripeEvent.Data.Object as Stripe.PaymentIntent;
            if (paymentIntent == null)
            {
                _logger.LogWarning("PaymentIntentPaymentFailed event received but PaymentIntent object was null");
                return;
            }

            var order = await _unitOfWork.Orders.GetByStripePaymentIntentIdAsync(paymentIntent.Id, cancellationToken);
            if (order == null)
            {
                _logger.LogWarning("No order found for PaymentIntent {PaymentIntentId}", paymentIntent.Id);
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
        }
    }
}