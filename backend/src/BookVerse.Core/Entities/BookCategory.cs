using BookVerse.Core.Interfaces;

namespace BookVerse.Core.Entities;

public class BookCategory : ITimestampedEntity
{
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;

    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public DateTime CreatedAtUtc { get; set; }
}