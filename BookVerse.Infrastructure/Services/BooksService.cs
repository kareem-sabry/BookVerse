using AutoMapper;
using BookVerse.Application.Dtos.Book;
using BookVerse.Application.Interfaces;
using BookVerse.Core.Entities;
using BookVerse.Core.Models;
using BookVerse.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookVerse.Infrastructure.Services;

public class BooksService : IBooksService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<BooksService> _logger;
    private readonly IDateTimeProvider _dateTimeProvider;

    public BooksService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<BooksService> logger,
        IDateTimeProvider dateTimeProvider)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<PagedResult<BookReadDto>> GetPagedAsync(BookQueryParameters parameters)
    {
        var pagedBooks = await _unitOfWork.Books.GetPagedWithDetailsAsync(parameters);
        var bookDtos = _mapper.Map<IEnumerable<BookReadDto>>(pagedBooks.Items);

        return new PagedResult<BookReadDto>(
            bookDtos,
            pagedBooks.TotalCount,
            pagedBooks.CurrentPage,
            pagedBooks.PageSize
        );
    }

    public async Task<IEnumerable<BookReadDto>> GetAllAsync()
    {
        var books = await _unitOfWork.Books.GetAllAsync();
        return _mapper.Map<IEnumerable<BookReadDto>>(books);
    }

    public async Task<BookReadDto?> GetByIdAsync(int id)
    {
        var book = await _unitOfWork.Books.GetByIdWithDetailsAsync(id);

        if (book == null)
        {
            _logger.LogWarning("Book not found with ID: {BookId}", id);
            return null;
        }

        return _mapper.Map<BookReadDto>(book);
    }

    public async Task<BookReadDto> CreateAsync(BookCreateDto bookDto)
    {
        await _unitOfWork.BeginTransactionAsync();

        var book = _mapper.Map<Book>(bookDto);
        var existingBook = await _unitOfWork.Books.GetExistingBook(book);

        if (existingBook != null)
        {
            _logger.LogInformation("Book already exists: {BookTitle}", book.Title);
            await _unitOfWork.CommitTransactionAsync();
            return _mapper.Map<BookReadDto>(existingBook);
        }

        await _unitOfWork.Books.AddAsync(book);
        await _unitOfWork.SaveChangesAsync();

        // add relationships
        // add relationships
        foreach (var authorId in bookDto.AuthorIds)
        {
            var bookAuthor = new BookAuthor
            {
                BookId = book.Id,
                AuthorId = authorId,
                CreatedAtUtc = _dateTimeProvider.UtcNow
            };
            await _unitOfWork.Books.AddBookAuthorAsync(bookAuthor);
        }

        foreach (var categoryId in bookDto.CategoryIds)
        {
            var bookCategory = new BookCategory
            {
                BookId = book.Id,
                CategoryId = categoryId,
                CreatedAtUtc = _dateTimeProvider.UtcNow
            };
            await _unitOfWork.Books.AddBookCategoryAsync(bookCategory);
        }

        await _unitOfWork.SaveChangesAsync();
        await _unitOfWork.CommitTransactionAsync();

        var createdBook = await _unitOfWork.Books.GetByIdWithDetailsAsync(book.Id);
        return _mapper.Map<BookReadDto>(createdBook!);
    }

    public async Task<bool> UpdateAsync(int id, BookUpdateDto bookDto)
    {
        await _unitOfWork.BeginTransactionAsync();

        var book = await _unitOfWork.Books.GetByIdWithDetailsAsync(id);
        if (book == null)
        {
            _logger.LogWarning("Attempted to update non-existent book with ID: {BookId}", id);
            await _unitOfWork.RollbackTransactionAsync();
            return false;
        }

        //Update basic properties
        _mapper.Map(bookDto, book);
        _unitOfWork.Books.Update(book);

        //Remove existing author relationships
        var existingAuthorRelations = await _unitOfWork.Books.GetBookAuthorsAsync(id);
        _unitOfWork.Books.RemoveBookAuthors(existingAuthorRelations);

//Add new author relationships
        foreach (var authorId in bookDto.AuthorIds)
        {
            var bookAuthor = new BookAuthor
            {
                BookId = id,
                AuthorId = authorId,
                CreatedAtUtc = _dateTimeProvider.UtcNow
            };
            await _unitOfWork.Books.AddBookAuthorAsync(bookAuthor);
        }

//Remove existing category relationships
        var existingCategoryRelations = await _unitOfWork.Books.GetBookCategoriesAsync(id);
        _unitOfWork.Books.RemoveBookCategories(existingCategoryRelations);

//Add new category relationships
        foreach (var categoryId in bookDto.CategoryIds)
        {
            var bookCategory = new BookCategory
            {
                BookId = id,
                CategoryId = categoryId,
                CreatedAtUtc = _dateTimeProvider.UtcNow
            };
            await _unitOfWork.Books.AddBookCategoryAsync(bookCategory);
        }

        await _unitOfWork.SaveChangesAsync();
        await _unitOfWork.CommitTransactionAsync();

        _logger.LogInformation("Updated book: {BookId}", id);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var book = await _unitOfWork.Books.GetByIdWithDetailsAsync(id);

        if (book == null)
        {
            _logger.LogWarning("Attempted to delete non-existent book with ID: {BookId}", id);
            return false;
        }

        _unitOfWork.Books.Delete(book);
        await _unitOfWork.SaveChangesAsync();
        _logger.LogInformation("Deleted book: {BookId}", id);
        return true;
    }
}