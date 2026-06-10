using System.ComponentModel.DataAnnotations;

namespace BookVerse.Application.Dtos.Book;

public class BookUpdateDto
{
    [Required(ErrorMessage = "Title is required")]
    [StringLength(200, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 200 characters")]
    public string Title { get; set; } = string.Empty;

    [StringLength(2000, ErrorMessage = "Description cannot exceed 2000 characters")]
    public string? Description { get; set; }

    [StringLength(20, ErrorMessage = "ISBN cannot exceed 20 characters")]
    public string? ISBN { get; set; }

    [Required(ErrorMessage = "Price is required")]
    [Range(0.01, 9999.99, ErrorMessage = "Price must be between 0.01 and 9999.99")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Publish date is required")]
    public DateOnly PublishDate { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative")]
    public int QuantityInStock { get; set; }

    [Required(ErrorMessage = "At least one author is required")]
    [MinLength(1, ErrorMessage = "At least one author is required")]
    public List<int> AuthorIds { get; set; } = new();

    [Required(ErrorMessage = "At least one category is required")]
    [MinLength(1, ErrorMessage = "At least one category is required")]
    public List<int> CategoryIds { get; set; } = new();
}