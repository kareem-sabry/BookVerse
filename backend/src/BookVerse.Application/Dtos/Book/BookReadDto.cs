using BookVerse.Application.Dtos.Author;
using BookVerse.Application.Dtos.Category;

namespace BookVerse.Application.Dtos.Book;

public class BookReadDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? ISBN { get; set; }
    public decimal Price { get; set; }
    public DateOnly PublishDate { get; set; }
    public int QuantityInStock { get; set; }
    public List<AuthorBriefDto> Authors { get; set; } = new();
    public List<CategoryBriefDto> Categories { get; set; } = new();

    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
}