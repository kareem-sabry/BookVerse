using BookVerse.Application.Dtos.Payment;

namespace BookVerse.Application.Interfaces;

public interface IStripePaymentIntentService
{
    Task<PaymentIntentResult> CreateAsync(
        CreatePaymentIntentRequest request,
        CancellationToken cancellationToken = default);

    Task<PaymentIntentResult> GetAsync(
        string paymentIntentId,
        CancellationToken cancellationToken = default);
}