using BookVerse.Application.Dtos.Payment;

namespace BookVerse.Application.Interfaces;

public interface IStripeRefundService
{
    Task<RefundResult> RefundAsync(string paymentIntentId, CancellationToken cancellationToken = default);
}