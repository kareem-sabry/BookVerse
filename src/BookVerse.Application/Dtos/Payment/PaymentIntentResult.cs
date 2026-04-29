namespace BookVerse.Application.Dtos.Payment;

public sealed record PaymentIntentResult(
    string Id,
    string ClientSecret,
    string Status,
    long Amount,
    string Currency
);