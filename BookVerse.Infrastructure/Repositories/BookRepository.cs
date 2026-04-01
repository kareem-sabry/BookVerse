using BookVerse.Application.Interfaces;
using BookVerse.Core.Entities;
using BookVerse.Core.Models;
using BookVerse.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookVerse.Infrastructure.Repositories;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(AppDbContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _dbSet.AsNoTracking()
            .Include(b => b.BookAuthors).ThenInclude(ba => ba.Author)
            .Include(b => b.BookCategories).ThenInclude(bc => bc.Category)
            .ToListAsync();
    }

    public async Task<Book?> GetByIdWithDetailsAsync(int id)
    {
        return await _dbSet
            .AsNoTracking()
            .Include(b => b.BookAuthors).ThenInclude(ba => ba.Author)
            .Include(b => b.BookCategories)
            .ThenInclude(bc => bc.Category)
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<PagedResult<Book>> GetPagedWithDetailsAsync(BookQueryParameters parameters)
    {
        IQueryable<Book> query = _dbSet.AsNoTracking()
            .Include(b => b.BookAuthors).ThenInclude(ba => ba.Author)
            .Include(b => b.BookCategories)
            .ThenInclude(bc => bc.Category);

        // Apply filters
        query = ApplyFilters(query, parameters);

        // Apply Search
        if (!string.IsNullOrWhiteSpace(parameters.SearchTerm)) query = ApplySearch(query, parameters.SearchTerm);

        //Get Total count
        var totalCount = await query.CountAsync();

        //apply Sorting
        if (!string.IsNullOrWhiteSpace(parameters.SortBy))
            query = ApplySorting(query, parameters.SortBy, parameters.SortDescending);
        else
            //Default Sorting
            query = query.OrderByDescending(b => b.CreatedAtUtc);

        //Apply pagination
        var items = await query
            .Skip((parameters.PageNumber - 1) * parameters.PageSize)
            .Take(parameters.PageSize)
            .ToListAsync();
        return new PagedResult<Book>(items, totalCount, parameters.PageNumber, parameters.PageSize);
    }

    public async Task<Book?> GetExistingBook(Book book)
    {
        return await _dbSet
            .AsNoTracking()
            .Include(b => b.BookAuthors).ThenInclude(ba => ba.Author)
            .Include(b => b.BookCategories)
            .ThenInclude(bc => bc.Category)
            .FirstOrDefaultAsync(b => b.Title == book.Title);
    }

    public async Task AddBookAuthorAsync(BookAuthor bookAuthor)
    {
        await _context.BookAuthors.AddAsync(bookAuthor);
    }

    public async Task AddBookCategoryAsync(BookCategory bookCategory)
    {
        await _context.BookCategories.AddAsync(bookCategory);
    }

    public async Task<List<BookAuthor>> GetBookAuthorsAsync(int bookId)
    {
        return await _context.BookAuthors.Where(ba => ba.BookId == bookId).ToListAsync();
    }

    public async Task<List<BookCategory>> GetBookCategoriesAsync(int bookId)
    {
        return await _context.BookCategories.Where(bc => bc.BookId == bookId).ToListAsync();
    }

    public void RemoveBookAuthors(IEnumerable<BookAuthor> bookAuthors)
    {
        _context.BookAuthors.RemoveRange(bookAuthors);
    }

    public void RemoveBookCategories(IEnumerable<BookCategory> bookCategories)
    {
        _context.BookCategories.RemoveRange(bookCategories);
    }

    protected override IQueryable<Book> ApplySearch(IQueryable<Book> query, string searchTerm)
    {
        return query.Where(b =>
            b.Title.Contains(searchTerm) ||
            (b.Description != null && b.Description.Contains(searchTerm)) ||
            (b.ISBN != null && b.ISBN.Contains(searchTerm)) ||
            b.BookAuthors.Any(ba =>
                ba.Author.FirstName.Contains(searchTerm) ||
                ba.Author.LastName.Contains(searchTerm))
        );
    }

    private IQueryable<Book> ApplyFilters(IQueryable<Book> query, BookQueryParameters parameters)
    {
        if (parameters.MinPrice.HasValue) query = query.Where(b => b.Price >= parameters.MinPrice.Value);

        if (parameters.MaxPrice.HasValue) query = query.Where(b => b.Price <= parameters.MaxPrice.Value);

        if (parameters.AuthorId.HasValue)
            query = query.Where(b => b.BookAuthors.Any(ba => ba.AuthorId == parameters.AuthorId.Value));

        if (parameters.CategoryId.HasValue)
            query = query.Where(b => b.BookCategories.Any(bc => bc.CategoryId == parameters.CategoryId.Value));

        if (parameters.PublishedAfter.HasValue)
            query = query.Where(b => b.PublishDate >= parameters.PublishedAfter.Value);

        if (parameters.PublishedBefore.HasValue)
            query = query.Where(b => b.PublishDate <= parameters.PublishedBefore.Value);

        return query;
    }
}