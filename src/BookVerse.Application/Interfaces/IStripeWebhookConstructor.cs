using BookVerse.Application.Dtos.Payment;

namespace BookVerse.Application.Interfaces;

public interface IStripeWebhookConstructor
{
    ParsedStripeEvent ConstructEvent(string json, string stripeSignature, string webhookSecret);
}