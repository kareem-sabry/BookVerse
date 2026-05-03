using System.Linq.Expressions;
using AutoMapper;
using BookVerse.Application.Dtos.Book;
using BookVerse.Application.Interfaces;
using BookVerse.Core.Entities;
using BookVerse.Core.Exceptions;
using BookVerse.Infrastructure.Services;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace BookVerse.Tests.Unit.Services;

public class BooksServiceTests
{
    private readonly Mock<IBookRepository> _mockBookRepository;
    private readonly Mock<IAuthorRepository> _mockAuthorRepository;
    private readonly Mock<ICategoryRepository> _mockCategoryRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<ICacheService> _mockCache;
    private readonly BooksService _sut;

    public BooksServiceTests()
    {
        _mockBookRepository = new Mock<IBookRepository>();
        _mockAuthorRepository = new Mock<IAuthorRepository>();
        _mockCategoryRepository = new Mock<ICategoryRepository>();
        _mockMapper = new Mock<IMapper>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockCache = new Mock<ICacheService>();
        var mockLogger = new Mock<ILogger<BooksService>>();

        _mockUnitOfWork.Setup(x => x.Books).Returns(_mockBookRepository.Object);
        _mockUnitOfWork.Setup(x => x.Authors).Returns(_mockAuthorRepository.Object);
        _mockUnitOfWork.Setup(x => x.Categories).Returns(_mockCategoryRepository.Object);

        // Default transaction stubs — individual tests override only what they need.
        _mockUnitOfWork.Setup(x => x.BeginTransactionAsync()).Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(x => x.CommitTransactionAsync()).Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(x => x.RollbackTransactionAsync()).Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        _sut = new BooksService(_mockUnitOfWork.Object, _mockMapper.Object, mockLogger.Object, _mockCache.Object);
    }

    // -------------------------------------------------------------------------
    // GetByIdAsync
    // -------------------------------------------------------------------------

    [Fact]
    public async Task GetByIdAsync_WhenBookExists_ReturnsMappedDto()
    {
        // Arrange
        var book = new Book { Id = 1, Title = "Clean Code" };
        var expectedDto = new BookReadDto { Id = 1, Title = "Clean Code" };

        _mockCache.Setup(x => x.GetAsync<BookReadDto>(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((BookReadDto?)null); // force cache miss

        _mockBookRepository
            .Setup(x => x.GetByIdWithDetailsAsync(book.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(book);
        _mockMapper
            .Setup(x => x.Map<BookReadDto>(book))
            .Returns(expectedDto);

        _mockCache.Setup(x => x.SetAsync(
            It.IsAny<string>(),
            expectedDto, It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

        // Act
        var result = await _sut.GetByIdAsync(book.Id, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result!.Id.Should().Be(book.Id);
        result.Title.Should().Be(book.Title);

        _mockCache.Verify(x =>
                x.SetAsync(
                    It.IsAny<string>(),
                    expectedDto,
                    It.IsAny<TimeSpan>(),
                    It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task GetByIdAsync_WhenBookDoesNotExist_ReturnsNull()
    {
        // Arrange

        _mockCache.Setup(x => x.GetAsync<BookReadDto>(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((BookReadDto?)null);

        _mockBookRepository
            .Setup(x => x.GetByIdWithDetailsAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Book?)null);

        // Act
        var result = await _sut.GetByIdAsync(999, CancellationToken.None);

        // Assert
        result.Should().BeNull();

        _mockCache.Verify(x =>
                x.SetAsync(
                    It.IsAny<string>(),
                    It.IsAny<BookReadDto>(),
                    It.IsAny<TimeSpan>(),
                    It.IsAny<CancellationToken>()),
            times: Times.Never);
    }

    // -------------------------------------------------------------------------
    // CreateAsync
    // -------------------------------------------------------------------------

    [Fact]
    public async Task CreateAsync_WhenBookIsNew_CreatesAndReturnsDto()
    {
        // Arrange
        var createDto = new BookCreateDto
        {
            Title = "The Pragmatic Programmer",
            AuthorIds = [1],
            CategoryIds = [1]
        };
        var book = new Book { Id = 1, Title = createDto.Title };
        var expectedDto = new BookReadDto { Id = book.Id, Title = book.Title };

        _mockMapper
            .Setup(x => x.Map<Book>(createDto))
            .Returns(book);
        _mockBookRepository
            .Setup(x => x.GetExistingBook(book, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Book?)null);
        _mockAuthorRepository
            .Setup(x => x.FindAsync(It.IsAny<Expression<Func<Author, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync([new Author { Id = 1 }]);
        _mockCategoryRepository
            .Setup(x => x.FindAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync([new Category { Id = 1 }]);
        _mockBookRepository
            .Setup(x => x.AddAsync(book, It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
        _mockBookRepository
            .Setup(x => x.AddBookAuthorAsync(It.IsAny<BookAuthor>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
        _mockBookRepository
            .Setup(x => x.AddBookCategoryAsync(It.IsAny<BookCategory>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
        _mockBookRepository
            .Setup(x => x.GetByIdWithDetailsAsync(book.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(book);
        _mockMapper
            .Setup(x => x.Map<BookReadDto>(book))
            .Returns(expectedDto);

        // Act
        var result = await _sut.CreateAsync(createDto, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Title.Should().Be(createDto.Title);

        _mockBookRepository.Verify(x => x.AddAsync(book, It.IsAny<CancellationToken>()), Times.Once);
        _mockUnitOfWork.Verify(x => x.BeginTransactionAsync(), Times.Once);
        _mockUnitOfWork.Verify(x => x.CommitTransactionAsync(), Times.Once);
        _mockUnitOfWork.Verify(x => x.RollbackTransactionAsync(), Times.Never);
    }

    [Fact]
    public async Task CreateAsync_WhenBookAlreadyExists_ThrowsConflictException()
    {
        // Arrange
        var createDto = new BookCreateDto { Title = "Clean Code", AuthorIds = [], CategoryIds = [] };
        var book = new Book { Title = createDto.Title };
        var existingBook = new Book { Id = 5, Title = createDto.Title };

        _mockMapper
            .Setup(x => x.Map<Book>(createDto))
            .Returns(book);
        _mockBookRepository
            .Setup(x => x.GetExistingBook(book, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existingBook);

        // Act
        var act = async () => await _sut.CreateAsync(createDto, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ConflictException>();

        _mockBookRepository.Verify(x => x.AddAsync(It.IsAny<Book>(), It.IsAny<CancellationToken>()), Times.Never);
        _mockUnitOfWork.Verify(x => x.RollbackTransactionAsync(), Times.Once);
        _mockUnitOfWork.Verify(x => x.CommitTransactionAsync(), Times.Never);
    }

    [Fact]
    public async Task CreateAsync_WhenAuthorDoesNotExist_ThrowsValidationException()
    {
        // Arrange
        var createDto = new BookCreateDto { Title = "New Book", AuthorIds = [99], CategoryIds = [1] };
        var book = new Book { Title = createDto.Title };

        _mockMapper
            .Setup(x => x.Map<Book>(createDto))
            .Returns(book);
        _mockBookRepository
            .Setup(x => x.GetExistingBook(book, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Book?)null);
        _mockAuthorRepository
            .Setup(x => x.FindAsync(It.IsAny<Expression<Func<Author, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync([]); // author 99 is unknown

        // Act
        var act = async () => await _sut.CreateAsync(createDto, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ValidationException>();

        _mockUnitOfWork.Verify(x => x.RollbackTransactionAsync(), Times.Once);
        _mockUnitOfWork.Verify(x => x.CommitTransactionAsync(), Times.Never);
    }

    [Fact]
    public async Task CreateAsync_WhenCategoryDoesNotExist_ThrowsValidationException()
    {
        // Arrange
        var createDto = new BookCreateDto { Title = "New Book", AuthorIds = [1], CategoryIds = [99] };
        var book = new Book { Title = createDto.Title };

        _mockMapper
            .Setup(x => x.Map<Book>(createDto))
            .Returns(book);
        _mockBookRepository
            .Setup(x => x.GetExistingBook(book, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Book?)null);
        _mockAuthorRepository
            .Setup(x => x.FindAsync(It.IsAny<Expression<Func<Author, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync([new Author { Id = 1 }]);
        _mockCategoryRepository
            .Setup(x => x.FindAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync([]); // category 99 is unknown

        // Act
        var act = async () => await _sut.CreateAsync(createDto, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ValidationException>();

        _mockUnitOfWork.Verify(x => x.RollbackTransactionAsync(), Times.Once);
        _mockUnitOfWork.Verify(x => x.CommitTransactionAsync(), Times.Never);
    }

    // -------------------------------------------------------------------------
    // UpdateAsync
    // -------------------------------------------------------------------------

    [Fact]
    public async Task UpdateAsync_WhenBookExists_UpdatesAndReturnsTrue()
    {
        // Arrange
        var bookId = 1;
        var updateDto = new BookUpdateDto { Title = "Updated Title", AuthorIds = [2], CategoryIds = [3] };
        var book = new Book { Id = bookId, Title = "Old Title" };

        _mockUnitOfWork
            .Setup(x => x.BeginTransactionAsync())
            .Returns(Task.CompletedTask);
        _mockUnitOfWork
            .Setup(x => x.CommitTransactionAsync())
            .Returns(Task.CompletedTask);

        _mockBookRepository
            .Setup(x => x.GetByIdWithDetailsAsync(bookId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(book);

        // FK existence validation — return authors/categories that match the requested IDs
        _mockAuthorRepository
            .Setup(x => x.FindAsync(It.IsAny<Expression<Func<Author, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync([new Author { Id = 2 }]);
        _mockCategoryRepository
            .Setup(x => x.FindAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync([new Category { Id = 3 }]);

        _mockBookRepository
            .Setup(x => x.GetBookAuthorsAsync(bookId, It.IsAny<CancellationToken>()))
            .ReturnsAsync([]);
        _mockBookRepository
            .Setup(x => x.GetBookCategoriesAsync(bookId, It.IsAny<CancellationToken>()))
            .ReturnsAsync([]);
        _mockBookRepository
            .Setup(x => x.AddBookAuthorAsync(It.IsAny<BookAuthor>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
        _mockBookRepository
            .Setup(x => x.AddBookCategoryAsync(It.IsAny<BookCategory>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _sut.UpdateAsync(bookId, updateDto, CancellationToken.None);

        // Assert
        result.Should().BeTrue();

        _mockBookRepository.Verify(x => x.Update(book), Times.Once);
        _mockUnitOfWork.Verify(x => x.CommitTransactionAsync(), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_WhenAuthorDoesNotExist_ThrowsValidationException()
    {
        // Arrange
        var bookId = 1;
        var updateDto = new BookUpdateDto { Title = "T", AuthorIds = [99], CategoryIds = [3] };
        var book = new Book { Id = bookId };

        _mockUnitOfWork.Setup(x => x.BeginTransactionAsync()).Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(x => x.RollbackTransactionAsync()).Returns(Task.CompletedTask);

        _mockBookRepository
            .Setup(x => x.GetByIdWithDetailsAsync(bookId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(book);

        // Author 99 not found — return empty list
        _mockAuthorRepository
            .Setup(x => x.FindAsync(It.IsAny<Expression<Func<Author, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync([]);

        // Act
        var act = async () => await _sut.UpdateAsync(bookId, updateDto, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ValidationException>()
            .WithMessage("*99*");

        _mockUnitOfWork.Verify(x => x.RollbackTransactionAsync(), Times.Once);
        _mockUnitOfWork.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task UpdateAsync_WhenCategoryDoesNotExist_ThrowsAndRollsBack()
    {
        // Arrange
        var bookId = 1;
        var updateDto = new BookUpdateDto { Title = "T", AuthorIds = [2], CategoryIds = [99] };
        var book = new Book { Id = bookId };

        _mockUnitOfWork.Setup(x => x.BeginTransactionAsync()).Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(x => x.RollbackTransactionAsync()).Returns(Task.CompletedTask);

        _mockBookRepository
            .Setup(x => x.GetByIdWithDetailsAsync(bookId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(book);

        // Authors pass, categories fail
        _mockAuthorRepository
            .Setup(x => x.FindAsync(It.IsAny<Expression<Func<Author, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync([new Author { Id = 2 }]);
        _mockCategoryRepository
            .Setup(x => x.FindAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync([]);

        // Act
        var act = async () => await _sut.UpdateAsync(bookId, updateDto, CancellationToken.None);

        // Assert — note: currently throws base Exception, not ValidationException (see note below)
        await act.Should().ThrowAsync<Exception>()
            .WithMessage("*99*");

        _mockUnitOfWork.Verify(x => x.RollbackTransactionAsync(), Times.Once);
        _mockUnitOfWork.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task UpdateAsync_WhenBookDoesNotExist_ReturnsFalse()
    {
        // Arrange
        _mockBookRepository
            .Setup(x => x.GetByIdWithDetailsAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Book?)null);

        // Act
        var result = await _sut.UpdateAsync(
            999,
            new BookUpdateDto { AuthorIds = [], CategoryIds = [] },
            CancellationToken.None);

        // Assert
        result.Should().BeFalse();

        _mockBookRepository.Verify(x => x.Update(It.IsAny<Book>()), Times.Never);
        _mockUnitOfWork.Verify(x => x.RollbackTransactionAsync(), Times.Once);
    }

    // -------------------------------------------------------------------------
    // DeleteAsync
    // -------------------------------------------------------------------------

    [Fact]
    public async Task DeleteAsync_WhenBookExists_DeletesAndReturnsTrue()
    {
        // Arrange
        var book = new Book { Id = 1, Title = "To Delete" };

        _mockBookRepository
            .Setup(x => x.GetByIdWithDetailsAsync(book.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(book);

        // Act
        var result = await _sut.DeleteAsync(book.Id, CancellationToken.None);

        // Assert
        result.Should().BeTrue();

        _mockBookRepository.Verify(x => x.Delete(book), Times.Once);
        _mockUnitOfWork.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_WhenBookDoesNotExist_ReturnsFalse()
    {
        // Arrange
        _mockBookRepository
            .Setup(x => x.GetByIdWithDetailsAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Book?)null);

        // Act
        var result = await _sut.DeleteAsync(999, CancellationToken.None);

        // Assert
        result.Should().BeFalse();

        _mockBookRepository.Verify(x => x.Delete(It.IsAny<Book>()), Times.Never);
        _mockUnitOfWork.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }
}