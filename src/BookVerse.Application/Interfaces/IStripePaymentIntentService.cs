using Stripe;

namespace BookVerse.Application.Interfaces;

public interface IStripePaymentIntentService
{
    Task<PaymentIntent> CreateAsync(
        PaymentIntentCreateOptions options,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default);

    Task<PaymentIntent> GetAsync(string paymentIntentId,
        CancellationToken cancellationToken = default);
}