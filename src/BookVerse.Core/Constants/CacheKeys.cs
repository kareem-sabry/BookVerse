namespace BookVerse.Core.Constants;

public static class CacheKeys
{
    public static string Book(int id) => $"book:{id}";
    public const string BooksPagePrefix = "books:page:";

    public static string BooksPage(int page, int size, string? search, string? sort)
        => $"{BooksPagePrefix}{page}:{size}:{search ?? "none"}:{sort ?? "none"}";
}