using Stripe;

namespace BookVerse.Application.Interfaces;

public interface IStripeWebhookConstructor
{
    Event ConstructEvent(string json, string stripeSignature, string webhookSecret);
}