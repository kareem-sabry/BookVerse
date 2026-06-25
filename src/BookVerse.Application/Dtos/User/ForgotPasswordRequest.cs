using System.ComponentModel.DataAnnotations;

namespace BookVerse.Application.Dtos.User;

public class ForgotPasswordRequest
{
    [Required] [EmailAddress] public string Email { get; set; } = string.Empty;
}