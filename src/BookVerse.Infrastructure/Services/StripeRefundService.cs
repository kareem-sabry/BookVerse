using BookVerse.Application.Dtos.Payment;
using BookVerse.Application.Interfaces;
using Stripe;

namespace BookVerse.Infrastructure.Services;

public class StripeRefundService : IStripeRefundService
{
    private readonly RefundService _service;

    public StripeRefundService(RefundService service)
    {
        _service = service;
    }

    public async Task<RefundResult> RefundAsync(string paymentIntentId, CancellationToken cancellationToken = default)
    {
        var options = new RefundCreateOptions
        {
            PaymentIntent = paymentIntentId
        };

        var refund = await _service.CreateAsync(options, null, cancellationToken);
        return new RefundResult(refund.Id, refund.Status, refund.Amount, refund.Currency);
    }
}