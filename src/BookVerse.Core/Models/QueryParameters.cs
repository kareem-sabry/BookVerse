using BookVerse.Core.Constants;

namespace BookVerse.Core.Models;

public class QueryParameters
{
    private const int MaxPageSize = ApplicationConstants.MaxPageSize;
    private int _pageSize = ApplicationConstants.DefaultPageSize;
    private int _pageNumber = 1;

    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = value < 1 ? 1 : value;
    }

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value < 1 ? 1 : value > MaxPageSize ? MaxPageSize : value;
    }

    public string? SortBy { get; set; }
    public bool SortDescending { get; set; } = false;
    public string? SearchTerm { get; set; }
}