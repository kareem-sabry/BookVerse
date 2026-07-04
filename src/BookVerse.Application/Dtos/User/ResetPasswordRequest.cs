using System.ComponentModel.DataAnnotations;

namespace BookVerse.Application.Dtos.User;

public class ResetPasswordRequest
{
    [Required]
    [EmailAddress]
    [StringLength(256)]
    public string Email { get; set; } = string.Empty;

    [Required] public string ResetCode { get; set; } = string.Empty;

    [Required] public string NewPassword { get; set; } = string.Empty;
}