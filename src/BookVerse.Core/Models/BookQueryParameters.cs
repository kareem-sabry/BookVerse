namespace BookVerse.Core.Models;

public class BookQueryParameters : QueryParameters
{
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public int? AuthorId { get; set; }
    public int? CategoryId { get; set; }
    public DateOnly? PublishedAfter { get; set; }
    public DateOnly? PublishedBefore { get; set; }
}