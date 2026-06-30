using BookVerse.Application.Dtos.Payment;
using BookVerse.Application.Interfaces;
using Stripe;

namespace BookVerse.Infrastructure.Services;

public class StripeWebhookConstructor : IStripeWebhookConstructor
{
    public ParsedStripeEvent ConstructEvent(string json, string stripeSignature, string webhookSecret)
    {
        var stripeEvent = EventUtility.ConstructEvent(json, stripeSignature, webhookSecret, EventUtility.DefaultTimeTolerance);
        var paymentIntentId = (stripeEvent.Data.Object as PaymentIntent)?.Id;
        return new ParsedStripeEvent(stripeEvent.Type, paymentIntentId);
    }
}