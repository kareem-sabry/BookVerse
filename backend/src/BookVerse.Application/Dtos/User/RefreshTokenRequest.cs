using System.ComponentModel.DataAnnotations;

namespace BookVerse.Application.Dtos.User;

public record RefreshTokenRequest
{
    [Required(ErrorMessage = "Refresh token is required")]
    public string? RefreshToken { get; init; }
}