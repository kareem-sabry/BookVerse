using System.ComponentModel.DataAnnotations;

namespace BookVerse.Application.Dtos.User;

public class ResetPasswordRequest
{
    [Required] [EmailAddress] public string Email { get; set; } = string.Empty;

    [Required] public string ResetCode { get; set; } = string.Empty;

    [Required] public string NewPassword { get; set; } = string.Empty;
}