using BookVerse.Application.Dtos.Payment;
using BookVerse.Application.Interfaces;
using Stripe;

namespace BookVerse.Infrastructure.Services;

public class StripePaymentIntentService : IStripePaymentIntentService
{
    private readonly PaymentIntentService _service;

    public StripePaymentIntentService(PaymentIntentService service)
    {
        _service = service;
    }

    public async Task<PaymentIntentResult> CreateAsync(CreatePaymentIntentRequest request,
        CancellationToken cancellationToken = default)
    {
        var options = new PaymentIntentCreateOptions
        {
            Amount = request.Amount,
            Currency = request.Currency,
            Customer = request.CustomerId,
            Metadata = request.Metadata?.ToDictionary(k => k.Key, v => v.Value)
        };
        var intent = await _service.CreateAsync(options, null, cancellationToken);

        return MapToResult(intent);
    }


    public async Task<PaymentIntentResult> GetAsync(
        string paymentIntentId,
        CancellationToken cancellationToken = default)
    {
        var intent = await _service.GetAsync(paymentIntentId, null, cancellationToken: cancellationToken);
        return MapToResult(intent);
    }


    private static PaymentIntentResult MapToResult(PaymentIntent intent)
    {
        return new(intent.Id, intent.ClientSecret, intent.Status, intent.Amount, intent.Currency);
    }
}