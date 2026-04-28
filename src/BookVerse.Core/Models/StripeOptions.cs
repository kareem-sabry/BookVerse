using System.ComponentModel.DataAnnotations;

namespace BookVerse.Core.Models;

public class StripeOptions
{
    public const string StripeOptionsKey = "StripeOptions";

    [Required] public string SecretKey { get; set; } = string.Empty;

    [Required] public string PublishableKey { get; set; } = string.Empty;

    [Required] public string WebhookSecret { get; set; } = string.Empty;
}