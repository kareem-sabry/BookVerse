using BookVerse.Core.Entities;
using BookVerse.Core.Models;

namespace BookVerse.Application.Interfaces;

public interface IBookRepository : IGenericRepository<Book>
{
    Task<Book?> GetByIdWithDetailsAsync(int id);
    Task<PagedResult<Book>> GetPagedWithDetailsAsync(BookQueryParameters parameters);
    Task<Book?> GetExistingBook(Book book);
    Task AddBookAuthorAsync(BookAuthor bookAuthor);
    Task AddBookCategoryAsync(BookCategory bookCategory);
    Task<List<BookAuthor>> GetBookAuthorsAsync(int bookId);
    Task<List<BookCategory>> GetBookCategoriesAsync(int bookId);
    void RemoveBookAuthors(IEnumerable<BookAuthor> bookAuthors);
    void RemoveBookCategories(IEnumerable<BookCategory> bookCategories);
}