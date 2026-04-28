using System.ComponentModel.DataAnnotations;

namespace BookVerse.Application.Dtos.Category;

public class CategoryUpdateDto
{
    [Required(ErrorMessage = "Category name is required")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Category name must be between 1 and 100 characters")]
    public string Name { get; set; } = string.Empty;
}