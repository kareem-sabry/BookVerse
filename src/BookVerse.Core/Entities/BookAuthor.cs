using BookVerse.Core.Interfaces;

namespace BookVerse.Core.Entities;

public class BookAuthor : ITimestampedEntity
{
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;

    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;

    public DateTime CreatedAtUtc { get; set; }
}