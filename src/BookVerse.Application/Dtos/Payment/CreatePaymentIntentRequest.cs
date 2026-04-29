namespace BookVerse.Application.Dtos.Payment;

public sealed record CreatePaymentIntentRequest(
    long Amount,
    string Currency,
    string? CustomerId = null,
    IDictionary<string, string>? Metadata = null
);