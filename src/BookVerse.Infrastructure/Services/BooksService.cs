using AutoMapper;
using BookVerse.Application.Dtos.Book;
using BookVerse.Application.Interfaces;
using BookVerse.Core.Constants;
using BookVerse.Core.Entities;
using BookVerse.Core.Exceptions;
using BookVerse.Core.Models;
using Microsoft.Extensions.Logging;

namespace BookVerse.Infrastructure.Services;

public class BooksService : IBooksService
{
    private readonly ILogger<BooksService> _logger;
    private readonly ICacheService _cache;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public BooksService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<BooksService> logger, ICacheService cache)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
        _cache = cache;
    }

    public async Task<PagedResult<BookReadDto>> GetPagedAsync(BookQueryParameters parameters,
        CancellationToken cancellationToken)
    {
        var pagedBooks = await _unitOfWork.Books.GetPagedWithDetailsAsync(parameters, cancellationToken);
        var bookDtos = _mapper.Map<IEnumerable<BookReadDto>>(pagedBooks.Items);

        return new PagedResult<BookReadDto>(
            bookDtos,
            pagedBooks.TotalCount,
            pagedBooks.CurrentPage,
            pagedBooks.PageSize
        );
    }

    public async Task<BookReadDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var cacheKey = CacheKeys.Book(id);
        // trying redis first
        var cached = await _cache.GetAsync<BookReadDto>(cacheKey, cancellationToken);
        if (cached is not null)
            return cached;

        // cache miss - retrieving from database
        var book = await _unitOfWork.Books.GetByIdWithDetailsAsync(id, cancellationToken);

        if (book == null)
        {
            _logger.LogWarning("Book not found with ID: {BookId}", id);
            return null;
        }

        var dto = _mapper.Map<BookReadDto>(book);
        // Store in Redis for 5 minutes
        await _cache.SetAsync(cacheKey, dto, TimeSpan.FromMinutes(5), cancellationToken);
        return dto;
    }

    public async Task<BookReadDto> CreateAsync(BookCreateDto bookDto, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync();

        var book = _mapper.Map<Book>(bookDto);
        var existingBook = await _unitOfWork.Books.GetExistingBook(book, cancellationToken);

        if (existingBook != null)
        {
            _logger.LogWarning("Duplicate book creation attempted: {BookTitle}", book.Title);
            await _unitOfWork.RollbackTransactionAsync();
            throw new ConflictException($"A book with the title '{book.Title}' already exists.");
        }

        // Validate that all supplied AuthorIds and CategoryIds actually exist
        // before persisting anything, so we get a clear error rather than an FK violation 500.
        var existingAuthors = (await _unitOfWork.Authors.FindAsync(
                a => bookDto.AuthorIds.Contains(a.Id), cancellationToken))
            .Select(a => a.Id)
            .ToHashSet();
        var missingAuthor = bookDto.AuthorIds.FirstOrDefault(id => !existingAuthors.Contains(id));
        if (missingAuthor != default)
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw new ValidationException($"Author with ID {missingAuthor} does not exist.");
        }

        var existingCategories = (await _unitOfWork.Categories.FindAsync(
                c => bookDto.CategoryIds.Contains(c.Id), cancellationToken))
            .Select(c => c.Id)
            .ToHashSet();
        var missingCategory = bookDto.CategoryIds.FirstOrDefault(id => !existingCategories.Contains(id));
        if (missingCategory != default)
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw new ValidationException($"Category with ID {missingCategory} does not exist.");
        }

        await _unitOfWork.Books.AddAsync(book, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // add relationships
        foreach (var authorId in bookDto.AuthorIds)
        {
            var bookAuthor = new BookAuthor
            {
                BookId = book.Id,
                AuthorId = authorId,
            };
            await _unitOfWork.Books.AddBookAuthorAsync(bookAuthor, cancellationToken);
        }

        foreach (var categoryId in bookDto.CategoryIds)
        {
            var bookCategory = new BookCategory
            {
                BookId = book.Id,
                CategoryId = categoryId,
            };
            await _unitOfWork.Books.AddBookCategoryAsync(bookCategory, cancellationToken);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _unitOfWork.CommitTransactionAsync();

        var createdBook = await _unitOfWork.Books.GetByIdWithDetailsAsync(book.Id, cancellationToken);
        return _mapper.Map<BookReadDto>(createdBook!);
    }

    public async Task<bool> UpdateAsync(int id, BookUpdateDto bookDto, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync();

        var book = await _unitOfWork.Books.GetByIdWithDetailsAsync(id, cancellationToken);
        if (book == null)
        {
            _logger.LogWarning("Attempted to update non-existent book with ID: {BookId}", id);
            await _unitOfWork.RollbackTransactionAsync();
            return false;
        }

        //Validate authors exist before modifying
        var existingAuthors =
            (await _unitOfWork.Authors.FindAsync(a => bookDto.AuthorIds.Contains(a.Id), cancellationToken))
            .Select(a => a.Id)
            .ToHashSet();

        var missingAuthor = bookDto.AuthorIds.FirstOrDefault(id => !existingAuthors.Contains(id));

        if (missingAuthor != default)
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw new ValidationException($"Author with ID {missingAuthor} does not exist.");
        }

        //Validate categories exist

        var existingCategories =
            (await _unitOfWork.Categories.FindAsync(c => bookDto.CategoryIds.Contains(c.Id), cancellationToken))
            .Select(c => c.Id).ToHashSet();

        var missingCategory = bookDto.CategoryIds.FirstOrDefault(id => !existingCategories.Contains(id));

        if (missingCategory != default)
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw new ValidationException($"Category with ID {missingCategory} does not exist.");
        }

        //update basic properties
        _mapper.Map(bookDto, book);
        _unitOfWork.Books.Update(book);

        //Remove existing author relationships

        var existingAuthorRelations = await _unitOfWork.Books.GetBookAuthorsAsync(id, cancellationToken);
        _unitOfWork.Books.RemoveBookAuthors(existingAuthorRelations);

        // Add new author relationships

        foreach (var authorId in bookDto.AuthorIds)
        {
            var bookAuthor = new BookAuthor
            {
                BookId = id,
                AuthorId = authorId
            };
            await _unitOfWork.Books.AddBookAuthorAsync(bookAuthor, cancellationToken);
        }

        // Remove existing category relationships
        var existingCategoryRelations = await _unitOfWork.Books.GetBookCategoriesAsync(id, cancellationToken);
        _unitOfWork.Books.RemoveBookCategories(existingCategoryRelations);

        // Add new category relationships
        foreach (var categoryId in bookDto.CategoryIds)
        {
            var bookCategory = new BookCategory
            {
                BookId = id,
                CategoryId = categoryId,
            };
            await _unitOfWork.Books.AddBookCategoryAsync(bookCategory, cancellationToken);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _unitOfWork.CommitTransactionAsync();
        
        //Invalidate cache after update
        await _cache.RemoveAsync(CacheKeys.Book(id), cancellationToken);
        
        _logger.LogInformation("Updated book: {BookId}", id);
        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var book = await _unitOfWork.Books.GetByIdWithDetailsAsync(id, cancellationToken);

        if (book == null)
        {
            _logger.LogWarning("Attempted to delete non-existent book with ID: {BookId}", id);
            return false;
        }

        _unitOfWork.Books.Delete(book);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        // Invalidate cache so stale data is not retrieved.
        await _cache.RemoveAsync(CacheKeys.Book(id), cancellationToken);
        
        _logger.LogInformation("Deleted book: {BookId}", id);
        return true;
    }
}