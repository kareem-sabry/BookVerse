using System.ComponentModel.DataAnnotations;
using BookVerse.Core.Enums;

namespace BookVerse.Application.Dtos.User;

public record RegisterRequest
{
    [Required(ErrorMessage = "First name is required")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 100 characters")]
    public required string FirstName { get; init; }

    [Required(ErrorMessage = "Last name is required")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 100 characters")]
    public required string LastName { get; init; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    [StringLength(256, ErrorMessage = "Email cannot exceed 256 characters")]
    public required string Email { get; init; }

    [Required(ErrorMessage = "Password is required")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 100 characters")]
    public required string Password { get; init; }

    [Required(ErrorMessage = "Role is required")]
    [EnumDataType(typeof(Role), ErrorMessage = "Invalid role")]
    public required Role Role { get; init; }
}