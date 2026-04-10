using BookVerse.Application.Dtos.Payment;
using BookVerse.Application.Interfaces;
using BookVerse.Core.Constants;
using BookVerse.Core.Enums;
using BookVerse.Core.Exceptions;
using BookVerse.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;

namespace BookVerse.Infrastructure.Services;

public class PaymentService : IPaymentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly StripeOptions _stripeOptions;

    public PaymentService(IUnitOfWork unitOfWork, IOptions<StripeOptions> stripeOptions)
    {
        _unitOfWork = unitOfWork;
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
        _unitOfWork.SaveChangesAsync(cancellationToken);

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
            Console.WriteLine($"[ERROR] StripeException: {ex.Message}");
            throw new ValidationException(ErrorMessages.StripeWebhookSignatureInvalid);
        }

        if (stripeEvent.Type == EventTypes.PaymentIntentSucceeded)
        {
            var paymentIntent = stripeEvent.Data.Object as Stripe.PaymentIntent;
            if (paymentIntent == null)
            {
                Console.WriteLine("[WARN] PaymentIntent is null, skipping.");
                return;
            }

            Console.WriteLine($"[INFO] PaymentIntent succeeded: {paymentIntent.Id}");

            var order = await _unitOfWork.Orders.GetByStripePaymentIntentIdAsync(paymentIntent.Id,
                cancellationToken);
            if (order == null)
            {
                Console.WriteLine($"[WARN] Order not found for PaymentIntent: {paymentIntent.Id}");
                return;
            }

            order.PaymentStatus = PaymentStatus.Completed;
            order.Status = OrderStatus.Processing;
            _unitOfWork.Orders.Update(order);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            Console.WriteLine($"[INFO] Order {order.OrderNumber} updated to Completed/Processing.");
        }
        else if (stripeEvent.Type == EventTypes.PaymentIntentPaymentFailed)
        {
            var paymentIntent = stripeEvent.Data.Object as Stripe.PaymentIntent;
            if (paymentIntent == null)
            {
                Console.WriteLine("[WARN] PaymentIntent is null, skipping.");
                return;
            }

            var order = await _unitOfWork.Orders.GetByStripePaymentIntentIdAsync(paymentIntent.Id, cancellationToken);
            if (order == null)
            {
                Console.WriteLine($"[WARN] Order not found for PaymentIntent: {paymentIntent.Id}");
                return;
            }

            order.PaymentStatus = PaymentStatus.Failed;
            _unitOfWork.Orders.Update(order);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            Console.WriteLine($"[INFO] Order {order.OrderNumber} payment marked as Failed.");
        }
    }
}