using BookVerse.Application.Dtos.Payment;

namespace BookVerse.Application.Interfaces;

public interface IPaymentService
{
    Task<PaymentIntentResponseDto> CreatePaymentIntentAsync(int orderId, Guid userId, CancellationToken cancellationToken = default);
    Task HandleWebhookAsync(string json, string stripeSignature, CancellationToken cancellationToken = default);
}