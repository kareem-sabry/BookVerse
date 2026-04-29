using BookVerse.Application.Interfaces;
using Stripe;

namespace BookVerse.Infrastructure.Services;

public class StripeWebhookConstructor : IStripeWebhookConstructor
{
    public Event ConstructEvent(string json, string stripeSignature, string webhookSecret)
        => EventUtility.ConstructEvent(json, stripeSignature, webhookSecret);
}