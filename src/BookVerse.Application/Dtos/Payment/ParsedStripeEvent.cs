namespace BookVerse.Application.Dtos.Payment;

/// <summary>
/// Stripe-SDK-free representation of a parsed webhook event.
/// Infrastructure maps Stripe.Event → this type so Application
/// has zero dependency on the Stripe SDK.
/// </summary>
public sealed record ParsedStripeEvent(
    string EventType,
    string? PaymentIntentId,
    DateTime EventCreatedAtUtc);