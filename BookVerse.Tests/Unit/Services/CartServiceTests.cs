using AutoMapper;
using BookVerse.Application.Dtos.Cart;
using BookVerse.Application.Interfaces;
using BookVerse.Core.Constants;
using BookVerse.Core.Entities;
using BookVerse.Core.Exceptions;
using BookVerse.Infrastructure.Services;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace BookVerse.Tests.Unit.Services;

public class CartServiceTests
{
    private readonly Mock<IBookRepository> _mockBookRepository;
    private readonly Mock<ICartRepository> _mockCartRepository;
    private readonly Mock<IDateTimeProvider> _mockDateTimeProvider;
    private readonly Mock<ILogger<CartService>> _mockLogger;
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly CartService _sut;

    public CartServiceTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockMapper = new Mock<IMapper>();
        _mockLogger = new Mock<ILogger<CartService>>();
        _mockDateTimeProvider = new Mock<IDateTimeProvider>();
        _mockCartRepository = new Mock<ICartRepository>();
        _mockBookRepository = new Mock<IBookRepository>();

        // Default date for all tests
        _mockDateTimeProvider.Setup(x => x.UtcNow)
            .Returns(new DateTime(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc));

        // Setup UnitOfWork to return mocked repositories
        _mockUnitOfWork.Setup(x => x.Carts).Returns(_mockCartRepository.Object);
        _mockUnitOfWork.Setup(x => x.Books).Returns(_mockBookRepository.Object);

        _sut = new CartService(
            _mockUnitOfWork.Object,
            _mockMapper.Object,
            _mockLogger.Object);
    }

    #region GetCartByUserIdAsync Tests

    [Fact]
    public async Task GetCartByUserIdAsync_WithExistingCart_ReturnsCartDto()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var cart = new Cart
        {
            Id = 1,
            UserId = userId,
            CartItems = new List<CartItem>
            {
                new()
                {
                    Id = 1,
                    BookId = 1,
                    Quantity = 2,
                    PriceAtAdd = 19.99m,
                    Book = new Book { Id = 1, Title = "Test Book", Price = 19.99m }
                }
            }
        };

        var cartDto = new CartDto
        {
            Id = 1,
            UserId = userId,
            CartItems = new List<CartItemDto>
            {
                new()
                {
                    Id = 1,
                    BookId = 1,
                    BookTitle = "Test Book",
                    Price = 19.99m,
                    Quantity = 2
                }
            }
        };

        _mockCartRepository.Setup(x => x.GetUserCartAsync(userId, It.IsAny<CancellationToken>())).ReturnsAsync(cart);
        _mockMapper.Setup(x => x.Map<CartDto>(cart)).Returns(cartDto);

        // Act
        var result = await _sut.GetCartByUserIdAsync(userId, It.IsAny<CancellationToken>());

        // Assert
        result.Should().NotBeNull();
        result!.Id.Should().Be(1);
        result.UserId.Should().Be(userId);
        result.CartItems.Should().HaveCount(1);
        result.TotalItems.Should().Be(2);

        _mockCartRepository.Verify(x => x.GetUserCartAsync(userId, It.IsAny<CancellationToken>()), Times.Once);
        _mockMapper.Verify(x => x.Map<CartDto>(cart), Times.Once);
    }

    [Fact]
    public async Task GetCartByUserIdAsync_WithNoCart_ReturnsNull()
    {
        // Arrange
        var userId = Guid.NewGuid();

        _mockCartRepository.Setup(x => x.GetUserCartAsync(userId, It.IsAny<CancellationToken>())).ReturnsAsync((Cart?)null);

        // Act
        var result = await _sut.GetCartByUserIdAsync(userId, It.IsAny<CancellationToken>());

        // Assert
        result.Should().BeNull();

        _mockCartRepository.Verify(x => x.GetUserCartAsync(userId, It.IsAny<CancellationToken>()), Times.Once);
        _mockMapper.Verify(x => x.Map<CartDto>(It.IsAny<Cart>()), Times.Never);
    }

    #endregion

    #region AddToCartAsync Tests

    [Fact]
    public async Task AddToCartAsync_WithNewCart_CreatesCartAndAddsItem()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var cartItemAdd = new CartItemAdd
        {
            BookId = 1,
            Quantity = 2
        };

        var book = new Book
        {
            Id = 1,
            Title = "Test Book",
            Price = 19.99m,
            QuantityInStock = 10
        };

        var newCart = new Cart
        {
            Id = 1,
            UserId = userId,
            CartItems = new List<CartItem>()
        };

        var updatedCart = new Cart
        {
            Id = 1,
            UserId = userId,
            CartItems = new List<CartItem>
            {
                new()
                {
                    Id = 1,
                    CartId = 1,
                    BookId = 1,
                    Quantity = 2,
                    PriceAtAdd = 19.99m,
                    Book = book
                }
            }
        };

        var cartDto = new CartDto
        {
            Id = 1,
            UserId = userId,
            CartItems = new List<CartItemDto>
            {
                new()
                {
                    Id = 1,
                    BookId = 1,
                    BookTitle = "Test Book",
                    Price = 19.99m,
                    Quantity = 2
                }
            }
        };

        _mockCartRepository.Setup(x => x.GetUserCartAsync(userId, It.IsAny<CancellationToken>())).ReturnsAsync((Cart?)null);
        _mockCartRepository.Setup(x => x.AddAsync(It.IsAny<Cart>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
        _mockBookRepository.Setup(x => x.GetByIdAsync(cartItemAdd.BookId, It.IsAny<CancellationToken>())).ReturnsAsync(book);
        _mockCartRepository.Setup(x => x.GetCartItemAsync(It.IsAny<int>(), cartItemAdd.BookId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((CartItem?)null);
        _mockCartRepository.Setup(x => x.AddCartItemAsync(It.IsAny<CartItem>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
        _mockCartRepository
            .Setup(x => x.GetCartWithItemsAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(updatedCart);
        _mockMapper.Setup(x => x.Map<CartDto>(updatedCart)).Returns(cartDto);
        _mockUnitOfWork.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);
        _mockUnitOfWork.Setup(x => x.BeginTransactionAsync()).Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(x => x.CommitTransactionAsync()).Returns(Task.CompletedTask);

        // Act
        var result = await _sut.AddToCartAsync(userId, cartItemAdd, It.IsAny<CancellationToken>());

        // Assert
        result.Should().NotBeNull();
        result.CartItems.Should().HaveCount(1);
        result.CartItems[0].Quantity.Should().Be(2);

        _mockCartRepository.Verify(x => x.AddAsync(It.IsAny<Cart>(), It.IsAny<CancellationToken>()), Times.Once);
        _mockCartRepository.Verify(x => x.AddCartItemAsync(It.IsAny<CartItem>(), It.IsAny<CancellationToken>()), Times.Once);
        _mockUnitOfWork.Verify(x => x.SaveChangesAsync(default), Times.Exactly(2));
        _mockUnitOfWork.Verify(x => x.CommitTransactionAsync(), Times.Once);
    }

    [Fact]
    public async Task AddToCartAsync_WithExistingCart_AddsItemToCart()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var cartItemAdd = new CartItemAdd
        {
            BookId = 1,
            Quantity = 2
        };

        var book = new Book
        {
            Id = 1,
            Title = "Test Book",
            Price = 19.99m,
            QuantityInStock = 10
        };

        var existingCart = new Cart
        {
            Id = 1,
            UserId = userId,
            CartItems = new List<CartItem>()
        };

        var updatedCart = new Cart
        {
            Id = 1,
            UserId = userId,
            CartItems = new List<CartItem>
            {
                new()
                {
                    Id = 1,
                    CartId = 1,
                    BookId = 1,
                    Quantity = 2,
                    PriceAtAdd = 19.99m,
                    Book = book
                }
            }
        };

        var cartDto = new CartDto
        {
            Id = 1,
            UserId = userId,
            CartItems = new List<CartItemDto>
            {
                new()
                {
                    Id = 1,
                    BookId = 1,
                    BookTitle = "Test Book",
                    Price = 19.99m,
                    Quantity = 2
                }
            }
        };

        _mockCartRepository.Setup(x => x.GetUserCartAsync(userId, It.IsAny<CancellationToken>())).ReturnsAsync(existingCart);
        _mockBookRepository.Setup(x => x.GetByIdAsync(cartItemAdd.BookId, It.IsAny<CancellationToken>())).ReturnsAsync(book);
        _mockCartRepository.Setup(x => x.GetCartItemAsync(existingCart.Id, cartItemAdd.BookId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((CartItem?)null);
        _mockCartRepository.Setup(x => x.AddCartItemAsync(It.IsAny<CartItem>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
        _mockCartRepository.Setup(x => x.GetCartWithItemsAsync(existingCart.Id, It.IsAny<CancellationToken>())).ReturnsAsync(updatedCart);
        _mockMapper.Setup(x => x.Map<CartDto>(updatedCart)).Returns(cartDto);
        _mockUnitOfWork.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);
        _mockUnitOfWork.Setup(x => x.BeginTransactionAsync()).Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(x => x.CommitTransactionAsync()).Returns(Task.CompletedTask);

        // Act
        var result = await _sut.AddToCartAsync(userId, cartItemAdd, It.IsAny<CancellationToken>());

        // Assert
        result.Should().NotBeNull();
        result.CartItems.Should().HaveCount(1);

        _mockCartRepository.Verify(x => x.AddAsync(It.IsAny<Cart>(), It.IsAny<CancellationToken>()), Times.Never);
        _mockCartRepository.Verify(x => x.AddCartItemAsync(It.IsAny<CartItem>(), It.IsAny<CancellationToken>()), Times.Once);
        _mockUnitOfWork.Verify(x => x.CommitTransactionAsync(), Times.Once);
    }

    [Fact]
    public async Task AddToCartAsync_WithExistingCartItem_UpdatesQuantity()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var cartItemAdd = new CartItemAdd
        {
            BookId = 1,
            Quantity = 2
        };

        var book = new Book
        {
            Id = 1,
            Title = "Test Book",
            Price = 19.99m,
            QuantityInStock = 10
        };

        var existingCart = new Cart
        {
            Id = 1,
            UserId = userId,
            CartItems = new List<CartItem>()
        };

        var existingCartItem = new CartItem
        {
            Id = 1,
            CartId = 1,
            BookId = 1,
            Quantity = 3,
            PriceAtAdd = 19.99m
        };

        var updatedCart = new Cart
        {
            Id = 1,
            UserId = userId,
            CartItems = new List<CartItem>
            {
                new()
                {
                    Id = 1,
                    CartId = 1,
                    BookId = 1,
                    Quantity = 5,
                    PriceAtAdd = 19.99m,
                    Book = book
                }
            }
        };

        var cartDto = new CartDto
        {
            Id = 1,
            UserId = userId,
            CartItems = new List<CartItemDto>
            {
                new()
                {
                    Id = 1,
                    BookId = 1,
                    BookTitle = "Test Book",
                    Price = 19.99m,
                    Quantity = 5
                }
            }
        };

        _mockCartRepository.Setup(x => x.GetUserCartAsync(userId, It.IsAny<CancellationToken>())).ReturnsAsync(existingCart);
        _mockBookRepository.Setup(x => x.GetByIdAsync(cartItemAdd.BookId, It.IsAny<CancellationToken>())).ReturnsAsync(book);
        _mockCartRepository.Setup(x => x.GetCartItemAsync(existingCart.Id, cartItemAdd.BookId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existingCartItem);
        _mockCartRepository.Setup(x => x.GetCartWithItemsAsync(existingCart.Id, It.IsAny<CancellationToken>())).ReturnsAsync(updatedCart);
        _mockMapper.Setup(x => x.Map<CartDto>(updatedCart)).Returns(cartDto);
        _mockUnitOfWork.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);
        _mockUnitOfWork.Setup(x => x.BeginTransactionAsync()).Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(x => x.CommitTransactionAsync()).Returns(Task.CompletedTask);

        // Act
        var result = await _sut.AddToCartAsync(userId, cartItemAdd, It.IsAny<CancellationToken>());

        // Assert
        result.Should().NotBeNull();
        result.CartItems[0].Quantity.Should().Be(5);

        _mockCartRepository.Verify(x => x.UpdateCartItem(existingCartItem, It.IsAny<CancellationToken>()), Times.Once);
        _mockCartRepository.Verify(x => x.AddCartItemAsync(It.IsAny<CartItem>(), It.IsAny<CancellationToken>()), Times.Never);
        _mockUnitOfWork.Verify(x => x.CommitTransactionAsync(), Times.Once);
    }

    [Fact]
    public async Task AddToCartAsync_WithNonExistentBook_NotFoundException()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var cartItemAdd = new CartItemAdd
        {
            BookId = 999,
            Quantity = 2
        };

        var existingCart = new Cart
        {
            Id = 1,
            UserId = userId,
            CartItems = new List<CartItem>()
        };

        _mockCartRepository.Setup(x => x.GetUserCartAsync(userId, It.IsAny<CancellationToken>())).ReturnsAsync(existingCart);
        _mockBookRepository.Setup(x => x.GetByIdAsync(cartItemAdd.BookId, It.IsAny<CancellationToken>())).ReturnsAsync((Book?)null);
        _mockUnitOfWork.Setup(x => x.BeginTransactionAsync()).Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(x => x.RollbackTransactionAsync()).Returns(Task.CompletedTask);

        // Act
        var act = async () => await _sut.AddToCartAsync(userId, cartItemAdd, It.IsAny<CancellationToken>());

        // Assert
        await act.Should().ThrowAsync<NotFoundException>()
            .WithMessage(ErrorMessages.BookNotFound);

        _mockUnitOfWork.Verify(x => x.RollbackTransactionAsync(), Times.Once);
        _mockUnitOfWork.Verify(x => x.CommitTransactionAsync(), Times.Never);
    }

    [Fact]
    public async Task AddToCartAsync_WithInsufficientStock_ThrowsInvalidOperationException()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var cartItemAdd = new CartItemAdd
        {
            BookId = 1,
            Quantity = 15
        };

        var book = new Book
        {
            Id = 1,
            Title = "Test Book",
            Price = 19.99m,
            QuantityInStock = 5
        };

        var existingCart = new Cart
        {
            Id = 1,
            UserId = userId,
            CartItems = new List<CartItem>()
        };

        _mockCartRepository.Setup(x => x.GetUserCartAsync(userId, It.IsAny<CancellationToken>())).ReturnsAsync(existingCart);
        _mockBookRepository.Setup(x => x.GetByIdAsync(cartItemAdd.BookId, It.IsAny<CancellationToken>())).ReturnsAsync(book);
        _mockUnitOfWork.Setup(x => x.BeginTransactionAsync()).Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(x => x.RollbackTransactionAsync()).Returns(Task.CompletedTask);

        // Act
        var act = async () => await _sut.AddToCartAsync(userId, cartItemAdd, It.IsAny<CancellationToken>());

        // Assert
        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage(ErrorMessages.InsufficientStock);

        _mockUnitOfWork.Verify(x => x.RollbackTransactionAsync(), Times.Once);
        _mockUnitOfWork.Verify(x => x.CommitTransactionAsync(), Times.Never);
    }

    #endregion

    #region UpdateCartItemAsync Tests

    [Fact]
    public async Task UpdateCartItemAsync_WithValidData_UpdatesCartItem()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var cartItemId = 1;
        var cartItemUpdate = new CartItemUpdate
        {
            Quantity = 5
        };

        var book = new Book
        {
            Id = 1,
            Title = "Test Book",
            Price = 19.99m,
            QuantityInStock = 10
        };

        var cartItem = new CartItem
        {
            Id = cartItemId,
            CartId = 1,
            BookId = 1,
            Quantity = 2,
            PriceAtAdd = 19.99m,
            Book = book
        };

        var cart = new Cart
        {
            Id = 1,
            UserId = userId,
            CartItems = new List<CartItem> { cartItem }
        };

        var updatedCart = new Cart
        {
            Id = 1,
            UserId = userId,
            CartItems = new List<CartItem>
            {
                new()
                {
                    Id = cartItemId,
                    CartId = 1,
                    BookId = 1,
                    Quantity = 5,
                    PriceAtAdd = 19.99m,
                    Book = book
                }
            }
        };

        var cartDto = new CartDto
        {
            Id = 1,
            UserId = userId,
            CartItems = new List<CartItemDto>
            {
                new()
                {
                    Id = cartItemId,
                    BookId = 1,
                    BookTitle = "Test Book",
                    Price = 19.99m,
                    Quantity = 5
                }
            }
        };

        _mockCartRepository.Setup(x => x.GetUserCartAsync(userId, It.IsAny<CancellationToken>())).ReturnsAsync(cart);
        _mockBookRepository.Setup(x => x.GetByIdAsync(cartItem.BookId, It.IsAny<CancellationToken>())).ReturnsAsync(book);
        _mockCartRepository.Setup(x => x.GetCartWithItemsAsync(cart.Id, It.IsAny<CancellationToken>())).ReturnsAsync(updatedCart);
        _mockMapper.Setup(x => x.Map<CartDto>(updatedCart)).Returns(cartDto);
        _mockUnitOfWork.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);

        // Act
        var result = await _sut.UpdateCartItemAsync(userId, cartItemId, cartItemUpdate, It.IsAny<CancellationToken>());

        // Assert
        result.Should().NotBeNull();
        result!.CartItems[0].Quantity.Should().Be(5);

        _mockCartRepository.Verify(x => x.UpdateCartItem(cartItem, It.IsAny<CancellationToken>()), Times.Once);
        _mockUnitOfWork.Verify(x => x.SaveChangesAsync(default), Times.Once);
    }

    [Fact]
    public async Task UpdateCartItemAsync_WithNonExistentCart_ReturnsNull()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var cartItemId = 1;
        var cartItemUpdate = new CartItemUpdate
        {
            Quantity = 5
        };

        _mockCartRepository.Setup(x => x.GetUserCartAsync(userId, It.IsAny<CancellationToken>())).ReturnsAsync((Cart?)null);

        // Act
        var result = await _sut.UpdateCartItemAsync(userId, cartItemId, cartItemUpdate, It.IsAny<CancellationToken>());

        // Assert
        result.Should().BeNull();

        _mockCartRepository.Verify(x => x.UpdateCartItem(It.IsAny<CartItem>(), It.IsAny<CancellationToken>()), Times.Never);
        _mockUnitOfWork.Verify(x => x.SaveChangesAsync(default), Times.Never);
    }

    [Fact]
    public async Task UpdateCartItemAsync_WithNonExistentCartItem_ReturnsNull()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var cartItemId = 999;
        var cartItemUpdate = new CartItemUpdate
        {
            Quantity = 5
        };

        var cart = new Cart
        {
            Id = 1,
            UserId = userId,
            CartItems = new List<CartItem>()
        };

        _mockCartRepository.Setup(x => x.GetUserCartAsync(userId, It.IsAny<CancellationToken>())).ReturnsAsync(cart);

        // Act
        var result = await _sut.UpdateCartItemAsync(userId, cartItemId, cartItemUpdate, It.IsAny<CancellationToken>());

        // Assert
        result.Should().BeNull();

        _mockCartRepository.Verify(x => x.UpdateCartItem(It.IsAny<CartItem>(), It.IsAny<CancellationToken>()), Times.Never);
        _mockUnitOfWork.Verify(x => x.SaveChangesAsync(default), Times.Never);
    }

    [Fact]
    public async Task UpdateCartItemAsync_WithInsufficientStock_ThrowsInvalidOperationException()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var cartItemId = 1;
        var cartItemUpdate = new CartItemUpdate
        {
            Quantity = 20
        };

        var book = new Book
        {
            Id = 1,
            Title = "Test Book",
            Price = 19.99m,
            QuantityInStock = 5
        };

        var cartItem = new CartItem
        {
            Id = cartItemId,
            CartId = 1,
            BookId = 1,
            Quantity = 2,
            PriceAtAdd = 19.99m,
            Book = book
        };

        var cart = new Cart
        {
            Id = 1,
            UserId = userId,
            CartItems = new List<CartItem> { cartItem }
        };

        _mockCartRepository.Setup(x => x.GetUserCartAsync(userId, It.IsAny<CancellationToken>())).ReturnsAsync(cart);
        _mockBookRepository.Setup(x => x.GetByIdAsync(cartItem.BookId, It.IsAny<CancellationToken>())).ReturnsAsync(book);

        // Act
        var act = async () => await _sut.UpdateCartItemAsync(userId, cartItemId, cartItemUpdate, It.IsAny<CancellationToken>());

        // Assert
        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage(ErrorMessages.InsufficientStock);

        _mockCartRepository.Verify(x => x.UpdateCartItem(It.IsAny<CartItem>(), It.IsAny<CancellationToken>()), Times.Never);
        _mockUnitOfWork.Verify(x => x.SaveChangesAsync(default), Times.Never);
    }

    #endregion

    #region RemoveCartItemAsync Tests

    [Fact]
    public async Task RemoveCartItemAsync_WithValidData_RemovesCartItem()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var cartItemId = 1;

        var cartItem = new CartItem
        {
            Id = cartItemId,
            CartId = 1,
            BookId = 1,
            Quantity = 2,
            PriceAtAdd = 19.99m
        };

        var cart = new Cart
        {
            Id = 1,
            UserId = userId,
            CartItems = new List<CartItem> { cartItem }
        };

        _mockCartRepository.Setup(x => x.GetUserCartAsync(userId, It.IsAny<CancellationToken>())).ReturnsAsync(cart);
        _mockUnitOfWork.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);

        // Act
        var result = await _sut.RemoveCartItemAsync(userId, cartItemId, It.IsAny<CancellationToken>());

        // Assert
        result.Should().NotBeNull();
        result.Succeeded.Should().BeTrue();
        result.Message.Should().Be("Item removed from cart successfully");

        _mockCartRepository.Verify(x => x.DeleteCartItem(cartItem, It.IsAny<CancellationToken>()), Times.Once);
        _mockUnitOfWork.Verify(x => x.SaveChangesAsync(default), Times.Once);
    }

    [Fact]
    public async Task RemoveCartItemAsync_WithNonExistentCart_ReturnsFailure()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var cartItemId = 1;

        _mockCartRepository.Setup(x => x.GetUserCartAsync(userId, It.IsAny<CancellationToken>())).ReturnsAsync((Cart?)null);

        // Act
        var result = await _sut.RemoveCartItemAsync(userId, cartItemId, It.IsAny<CancellationToken>());

        // Assert
        result.Should().NotBeNull();
        result.Succeeded.Should().BeFalse();
        result.Message.Should().Be("Cart not found");

        _mockCartRepository.Verify(x => x.DeleteCartItem(It.IsAny<CartItem>(), It.IsAny<CancellationToken>()), Times.Never);
        _mockUnitOfWork.Verify(x => x.SaveChangesAsync(default), Times.Never);
    }

    [Fact]
    public async Task RemoveCartItemAsync_WithNonExistentCartItem_ReturnsFailure()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var cartItemId = 999;

        var cart = new Cart
        {
            Id = 1,
            UserId = userId,
            CartItems = new List<CartItem>()
        };

        _mockCartRepository.Setup(x => x.GetUserCartAsync(userId, It.IsAny<CancellationToken>())).ReturnsAsync(cart);

        // Act
        var result = await _sut.RemoveCartItemAsync(userId, cartItemId, It.IsAny<CancellationToken>());

        // Assert
        result.Should().NotBeNull();
        result.Succeeded.Should().BeFalse();
        result.Message.Should().Be("Cart item not found");

        _mockCartRepository.Verify(x => x.DeleteCartItem(It.IsAny<CartItem>(), It.IsAny<CancellationToken>()), Times.Never);
        _mockUnitOfWork.Verify(x => x.SaveChangesAsync(default), Times.Never);
    }

    #endregion

    #region ClearCartAsync Tests

    [Fact]
    public async Task ClearCartAsync_WithValidCart_ClearsAllItems()
    {
        // Arrange
        var userId = Guid.NewGuid();

        var cart = new Cart
        {
            Id = 1,
            UserId = userId,
            CartItems = new List<CartItem>
            {
                new() { Id = 1, CartId = 1, BookId = 1, Quantity = 2 },
                new() { Id = 2, CartId = 1, BookId = 2, Quantity = 3 }
            }
        };

        _mockCartRepository.Setup(x => x.GetUserCartAsync(userId, It.IsAny<CancellationToken>())).ReturnsAsync(cart);
        _mockCartRepository.Setup(x => x.ClearCartAsync(cart.Id, It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);

        // Act
        var result = await _sut.ClearCartAsync(userId, It.IsAny<CancellationToken>());

        // Assert
        result.Should().NotBeNull();
        result.Succeeded.Should().BeTrue();
        result.Message.Should().Be("Cart cleared successfully");

        _mockCartRepository.Verify(x => x.ClearCartAsync(cart.Id, It.IsAny<CancellationToken>()), Times.Once);
        _mockUnitOfWork.Verify(x => x.SaveChangesAsync(default), Times.Once);
    }

    [Fact]
    public async Task ClearCartAsync_WithNonExistentCart_ReturnsFailure()
    {
        // Arrange
        var userId = Guid.NewGuid();

        _mockCartRepository.Setup(x => x.GetUserCartAsync(userId, It.IsAny<CancellationToken>())).ReturnsAsync((Cart?)null);

        // Act
        var result = await _sut.ClearCartAsync(userId, It.IsAny<CancellationToken>());

        // Assert
        result.Should().NotBeNull();
        result.Succeeded.Should().BeFalse();
        result.Message.Should().Be("Cart not found");

        _mockCartRepository.Verify(x => x.ClearCartAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Never);
        _mockUnitOfWork.Verify(x => x.SaveChangesAsync(default), Times.Never);
    }

    #endregion
}