using System.ComponentModel.DataAnnotations;

namespace BookVerse.Application.Dtos.User;

public record RefreshTokenRequest
{
    [Required(ErrorMessage = "Refresh token is required")]
    [StringLength(200)]
    public string? RefreshToken { get; init; }
}