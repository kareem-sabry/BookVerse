using BookVerse.Core.Entities;
using BookVerse.Core.Models;

namespace BookVerse.Application.Interfaces;

public interface IBookRepository : IGenericRepository<Book>
{
    Task<Book?> GetByIdWithDetailsAsync(int id, CancellationToken cancellationToken = default);

    Task<PagedResult<Book>> GetPagedWithDetailsAsync(BookQueryParameters parameters,
        CancellationToken cancellationToken = default);

    Task<Book?> GetExistingBook(Book book, CancellationToken cancellationToken = default);
    Task AddBookAuthorAsync(BookAuthor bookAuthor, CancellationToken cancellationToken = default);
    Task AddBookCategoryAsync(BookCategory bookCategory, CancellationToken cancellationToken = default);
    Task<List<BookAuthor>> GetBookAuthorsAsync(int bookId, CancellationToken cancellationToken = default);
    Task<List<BookCategory>> GetBookCategoriesAsync(int bookId, CancellationToken cancellationToken = default);
    void RemoveBookAuthors(IEnumerable<BookAuthor> bookAuthors, CancellationToken cancellationToken = default);
    void RemoveBookCategories(IEnumerable<BookCategory> bookCategories, CancellationToken cancellationToken = default);
}