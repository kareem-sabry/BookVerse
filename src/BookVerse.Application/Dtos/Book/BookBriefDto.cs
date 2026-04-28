namespace BookVerse.Application.Dtos.Book;

public class BookBriefDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateOnly PublishDate { get; set; }
    public decimal Price { get; set; }
}