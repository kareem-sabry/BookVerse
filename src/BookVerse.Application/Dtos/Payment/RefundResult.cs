namespace BookVerse.Application.Dtos.Payment;

public sealed record RefundResult(
    string Id,
    string Status,
    long Amount,
    string Currency
);