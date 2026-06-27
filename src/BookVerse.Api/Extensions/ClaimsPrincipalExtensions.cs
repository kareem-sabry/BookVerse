using System.Security.Claims;

namespace BookVerse.Api.Extensions;

public static class ClaimsPrincipalExtensions
{
    /// <summary>
    /// Extracts and parses the authenticated user's ID from the NameIdentifier claim.
    /// Returns null if the claim is missing or is not a valid GUID — callers should
    /// treat null the same way they previously treated a failed Guid.TryParse.
    /// </summary>
    public static Guid? GetUserId(this ClaimsPrincipal user)
    {
        var claim = user.FindFirstValue(ClaimTypes.NameIdentifier);
        return Guid.TryParse(claim, out var userId) ? userId : null;
    }

    /// <summary>
    /// Extracts the authenticated user's email from the Email claim.
    /// Returns null if the claim is missing or empty.
    /// </summary>
    public static string? GetUserEmail(this ClaimsPrincipal user)
    {
        var email = user.FindFirstValue(ClaimTypes.Email);
        return string.IsNullOrWhiteSpace(email) ? null : email;
    }
}