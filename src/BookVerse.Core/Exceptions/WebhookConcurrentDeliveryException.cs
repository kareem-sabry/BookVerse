namespace BookVerse.Core.Exceptions;

/// <summary>
/// Thrown when a concurrent webhook delivery causes a RowVersion conflict.
/// This is expected behavior — Stripe will retry and the ordering guard
/// will handle the retry correctly. Maps to 503 so Stripe knows to retry.
/// </summary>
public class WebhookConcurrentDeliveryException : Exception
{
    public WebhookConcurrentDeliveryException(string message, Exception inner) : base(message, inner)
    {
    }
}