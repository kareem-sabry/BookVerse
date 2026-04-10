namespace BookVerse.Application.Dtos.Payment;

public class PaymentIntentResponseDto
{
    public string ClientSecret { get; set; } = string.Empty;
    public string PublishableKey { get; set; } = string.Empty;
    public int OrderId { get; set; }
    public decimal Amount { get; set; }
}