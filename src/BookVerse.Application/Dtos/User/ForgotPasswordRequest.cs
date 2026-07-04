using System.ComponentModel.DataAnnotations;

namespace BookVerse.Application.Dtos.User;

public class ForgotPasswordRequest
{
    [Required]
    [EmailAddress]
    [StringLength(256)]
    public string Email { get; set; } = string.Empty;
}