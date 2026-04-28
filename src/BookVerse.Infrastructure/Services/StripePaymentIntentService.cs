using BookVerse.Application.Interfaces;
using Stripe;

namespace BookVerse.Infrastructure.Services;

public class StripePaymentIntentService : IStripePaymentIntentService
{
    private readonly PaymentIntentService _inner = new();

    public Task<PaymentIntent> CreateAsync(
        PaymentIntentCreateOptions options,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default)
        => _inner.CreateAsync(options, requestOptions, cancellationToken: cancellationToken);

    public Task<PaymentIntent> GetAsync(
        string paymentIntentId,
        CancellationToken cancellationToken = default)
        => _inner.GetAsync(paymentIntentId, cancellationToken: cancellationToken);
}