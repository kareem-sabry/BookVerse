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
    private readonly Mock<IDateTimeProvider> _mockDateTimeProvider;
    private readonly Mock<ILogger<BooksService>> _mockLogger;
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<IBookRepository> _mockBookRepository;
    private readonly BooksService _sut;

    public BooksServiceTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockMapper = new Mock<IMapper>();
        _mockLogger = new Mock<ILogger<BooksService>>();
        _mockDateTimeProvider = new Mock<IDateTimeProvider>();
        _mockBookRepository = new Mock<IBookRepository>();

        _mockDateTimeProvider.Setup(x => x.UtcNow)
            .Returns(new DateTime(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc));

        _mockUnitOfWork.Setup(x => x.Books).Returns(_mockBookRepository.Object);

        _sut = new BooksService(
            _mockUnitOfWork.Object,
            _mockMapper.Object,
            _mockLogger.Object);
    }

    #region GetByIdAsync Tests

    [Fact]
    public async Task GetByIdAsync_WhenBookExists_ReturnsMappedDto()
    {
        // Arrange
        var bookId = 1;
        var book = new Book { Id = bookId, Title = "Clean Code" };
        var expectedDto = new BookReadDto { Id = bookId, Title = "Clean Code" };

        _mockBookRepository
            .Setup(x => x.GetByIdWithDetailsAsync(bookId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(book);

        _mockMapper.Setup(x => x.Map<BookReadDto>(book)).Returns(expectedDto);

        // Act
        var result = await _sut.GetByIdAsync(bookId, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result!.Id.Should().Be(bookId);
        result.Title.Should().Be("Clean Code");
    }

    [Fact]
    public async Task GetByIdAsync_WhenBookDoesNotExist_ReturnsNull()
    {
        // Arrange
        _mockBookRepository
            .Setup(x => x.GetByIdWithDetailsAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Book?)null);

        // Act
        var result = await _sut.GetByIdAsync(999, CancellationToken.None);

        // Assert
        result.Should().BeNull();
    }

    #endregion

    #region CreateAsync Tests

    [Fact]
    public async Task CreateAsync_WhenBookIsNew_CreatesAndReturnsBook()
    {
        // Arrange
        var createDto = new BookCreateDto
        {
            Title = "The Pragmatic Programmer",
            AuthorIds = new List<int> { 1 },
            CategoryIds = new List<int> { 1 }
        };
        var book = new Book { Id = 1, Title = "The Pragmatic Programmer" };
        var expectedDto = new BookReadDto { Id = 1, Title = "The Pragmatic Programmer" };

        _mockMapper.Setup(x => x.Map<Book>(createDto)).Returns(book);
        _mockBookRepository
            .Setup(x => x.GetExistingBook(book, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Book?)null);
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
        _mockUnitOfWork.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
        _mockMapper.Setup(x => x.Map<BookReadDto>(book)).Returns(expectedDto);

        // Act
        var result = await _sut.CreateAsync(createDto, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Title.Should().Be("The Pragmatic Programmer");
        _mockBookRepository.Verify(x => x.AddAsync(book, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task CreateAsync_WhenBookAlreadyExists_ThrowsConflictException()
    {
        // Arrange
        var createDto = new BookCreateDto
            { Title = "Clean Code", AuthorIds = new List<int>(), CategoryIds = new List<int>() };
        var book = new Book { Title = "Clean Code" };
        var existingBook = new Book { Id = 5, Title = "Clean Code" };

        _mockMapper.Setup(x => x.Map<Book>(createDto)).Returns(book);
        _mockBookRepository
            .Setup(x => x.GetExistingBook(book, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existingBook);

        // Act
        var act = async () => await _sut.CreateAsync(createDto, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ConflictException>();
        _mockBookRepository.Verify(x => x.AddAsync(It.IsAny<Book>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    #endregion

    #region UpdateAsync Tests

    [Fact]
    public async Task UpdateAsync_WhenBookExists_UpdatesAndReturnsTrue()
    {
        // Arrange
        var bookId = 1;
        var updateDto = new BookUpdateDto
            { Title = "Updated Title", AuthorIds = new List<int> { 2 }, CategoryIds = new List<int> { 3 } };
        var book = new Book { Id = bookId, Title = "Old Title" };

        _mockBookRepository
            .Setup(x => x.GetByIdWithDetailsAsync(bookId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(book);
        _mockBookRepository
            .Setup(x => x.GetBookAuthorsAsync(bookId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<BookAuthor>());
        _mockBookRepository
            .Setup(x => x.GetBookCategoriesAsync(bookId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<BookCategory>());
        _mockBookRepository
            .Setup(x => x.AddBookAuthorAsync(It.IsAny<BookAuthor>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
        _mockBookRepository
            .Setup(x => x.AddBookCategoryAsync(It.IsAny<BookCategory>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        // Act
        var result = await _sut.UpdateAsync(bookId, updateDto, CancellationToken.None);

        // Assert
        result.Should().BeTrue();
        _mockBookRepository.Verify(x => x.Update(book), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_WhenBookDoesNotExist_ReturnsFalse()
    {
        // Arrange
        _mockBookRepository
            .Setup(x => x.GetByIdWithDetailsAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Book?)null);

        // Act
        var result = await _sut.UpdateAsync(999,
            new BookUpdateDto { AuthorIds = new List<int>(), CategoryIds = new List<int>() }, CancellationToken.None);

        // Assert
        result.Should().BeFalse();
        _mockBookRepository.Verify(x => x.Update(It.IsAny<Book>()), Times.Never);
    }

    #endregion

    #region DeleteAsync Tests

    [Fact]
    public async Task DeleteAsync_WhenBookExists_DeletesAndReturnsTrue()
    {
        // Arrange
        var bookId = 1;
        var book = new Book { Id = bookId, Title = "To Delete" };

        _mockBookRepository
            .Setup(x => x.GetByIdWithDetailsAsync(bookId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(book);
        _mockUnitOfWork.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
        ;

        // Act
        var result = await _sut.DeleteAsync(bookId, CancellationToken.None);

        // Assert
        result.Should().BeTrue();
        _mockBookRepository.Verify(x => x.Delete(book), Times.Once);
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
    }

    #endregion
}