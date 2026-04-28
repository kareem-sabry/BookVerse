using System.ComponentModel.DataAnnotations;

namespace BookVerse.Application.Dtos.Author;

public class AuthorUpdateDto
{
    [Required(ErrorMessage = "FirstName is required")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "First name must be between 1 and 100 characters")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "LastName is required")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "First name must be between 1 and 100 characters")]
    public string LastName { get; set; } = string.Empty;
}