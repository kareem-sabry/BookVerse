using System.ComponentModel.DataAnnotations;
using BookVerse.Core.Interfaces;

namespace BookVerse.Core.Entities;

public class Book : IAuditable, IEntity
{
    [Required] [MaxLength(200)] public string Title { get; set; } = string.Empty;

    [MaxLength(2000)] public string? Description { get; set; }

    [MaxLength(20)] public string? ISBN { get; set; }
    public decimal Price { get; set; }
    public DateOnly PublishDate { get; set; }
    public int QuantityInStock { get; set; }

    public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
    public ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }

    [MaxLength(100)] public string? CreatedBy { get; set; }

    [MaxLength(100)] public string? UpdatedBy { get; set; }
    [Key] public int Id { get; set; }
}