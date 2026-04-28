using System.ComponentModel.DataAnnotations;
using BookVerse.Core.Interfaces;

namespace BookVerse.Core.Entities;

public class Category : IAuditable, IEntity
{
    [Required] [MaxLength(100)] public string Name { get; set; } = string.Empty;
    public ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }

    [MaxLength(100)] public string? CreatedBy { get; set; }

    [MaxLength(100)] public string? UpdatedBy { get; set; }
    [Key] public int Id { get; set; }
}