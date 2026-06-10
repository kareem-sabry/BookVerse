using System.ComponentModel.DataAnnotations;
using BookVerse.Core.Constants;

namespace BookVerse.Application.Dtos.User;

public record LoginRequest
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    [StringLength(256, ErrorMessage = "Email cannot exceed 256 characters")]
    public required string Email { get; init; }

    [Required(ErrorMessage = "Password is required")]
    [StringLength(ApplicationConstants.MaxPasswordLength, MinimumLength = ApplicationConstants.MinPasswordLength,
        ErrorMessage = "Password must be between 8 and 100 characters")]
    public required string Password { get; init; }
}