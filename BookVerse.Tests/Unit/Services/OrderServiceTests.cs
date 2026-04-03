using AutoMapper;
using BookVerse.Application.Dtos.Order;
using BookVerse.Application.Interfaces;
using BookVerse.Core.Constants;
using BookVerse.Core.Entities;
using BookVerse.Core.Enums;
using BookVerse.Core.Models;
using BookVerse.Infrastructure.Services;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace BookVerse.Tests.Unit.Services;

public class OrderServiceTests
{
    private readonly Mock<IBookRepository> _mockBookRepository;
    private readonly Mock<ICartRepository> _mockCartRepository;
    private readonly Mock<IDateTimeProvider> _mockDateTimeProvider;
    private readonly Mock<ILogger<OrderService>> _mockLogger;
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IGenericRepository<OrderItem>> _mockOrderItemRepository;
    private readonly Mock<IOrderRepository> _mockOrderRepository;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly OrderService _sut;

    public OrderServiceTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockMapper = new Mock<IMapper>();
        _mockLogger = new Mock<ILogger<OrderService>>();
        _mockDateTimeProvider = new Mock<IDateTimeProvider>();
        _mockOrderRepository = new Mock<IOrderRepository>();
        _mockCartRepository = new Mock<ICartRepository>();
        _mockBookRepository = new Mock<IBookRepository>();
        _mockOrderItemRepository = new Mock<IGenericRepository<OrderItem>>();

        // Default date for all tests
        _mockDateTimeProvider.Setup(x => x.UtcNow)
            .Returns(new DateTime(2025, 1, 4, 12, 0, 0, DateTimeKind.Utc));

        _mockUnitOfWork.Setup(x => x.Orders).Returns(_mockOrderRepository.Object);
        _mockUnitOfWork.Setup(x => x.Carts).Returns(_mockCartRepository.Object);
        _mockUnitOfWork.Setup(x => x.Books).Returns(_mockBookRepository.Object);
        _mockUnitOfWork.Setup(x => x.OrderItems).Returns(_mockOrderItemRepository.Object);

        _sut = new OrderService(
            _mockUnitOfWork.Object,
            _mockMapper.Object,
            _mockLogger.Object,
            _mockDateTimeProvider.Object);
    }

    #region GetAllOrdersAsync Tests

    [Fact]
    public async Task GetAllOrdersAsync_ReturnsAllOrdersPaginated()
    {
        // Arrange
        var parameters = new QueryParameters
        {
            PageNumber = 1,
            PageSize = 10
        };

        var orders = new List<Order>
        {
            new()
            {
                Id = 1,
                UserId = Guid.NewGuid(),
                OrderNumber = "ORD-20250104-123456",
                TotalAmount = 99.97m,
                Status = OrderStatus.Pending,
                OrderItems = new List<OrderItem>()
            },
            new()
            {
                Id = 2,
                UserId = Guid.NewGuid(),
                OrderNumber = "ORD-20250103-654321",
                TotalAmount = 49.99m,
                Status = OrderStatus.Shipped,
                OrderItems = new List<OrderItem>()
            }
        };

        var pagedOrders = new PagedResult<Order>(orders, 2, 1, 10);

        var orderDtos = new List<OrderListDto>
        {
            new() { Id = 1, OrderNumber = "ORD-20250104-123456" },
            new() { Id = 2, OrderNumber = "ORD-20250103-654321" }
        };

        _mockOrderRepository.Setup(x => x.GetAllOrdersAsync(parameters, It.IsAny<CancellationToken>()))
            .ReturnsAsync(pagedOrders);
        _mockMapper.Setup(x => x.Map<IEnumerable<OrderListDto>>(orders))
            .Returns(orderDtos);

        // Act
        var result = await _sut.GetAllOrdersAsync(parameters, It.IsAny<CancellationToken>());

        // Assert
        result.Should().NotBeNull();
        result.Items.Should().HaveCount(2);
        result.TotalCount.Should().Be(2);

        _mockOrderRepository.Verify(x => x.GetAllOrdersAsync(parameters, It.IsAny<CancellationToken>()), Times.Once);
    }

    #endregion

    #region CreateOrderFromCartAsync Tests

    [Fact]
    public async Task CreateOrderFromCartAsync_WithValidCart_CreatesOrderSuccessfully()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var orderCreateDto = new OrderCreateDto
        {
            ShippingAddress = "123 Main St, New York, NY 10001",
            PaymentMethod = "Credit Card",
            Notes = "Please deliver between 9 AM - 5 PM"
        };

        var book1 = new Book
        {
            Id = 1,
            Title = "Clean Code",
            Price = 29.99m,
            QuantityInStock = 10
        };

        var book2 = new Book
        {
            Id = 2,
            Title = "Design Patterns",
            Price = 39.99m,
            QuantityInStock = 5
        };

        var cart = new Cart
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
                    PriceAtAdd = 29.99m,
                    Book = book1
                },
                new()
                {
                    Id = 2,
                    CartId = 1,
                    BookId = 2,
                    Quantity = 1,
                    PriceAtAdd = 39.99m,
                    Book = book2
                }
            }
        };

        var createdOrder = new Order
        {
            Id = 1,
            UserId = userId,
            OrderNumber = "ORD-20250104-123456",
            OrderDate = _mockDateTimeProvider.Object.UtcNow,
            Status = OrderStatus.Pending,
            PaymentStatus = PaymentStatus.Pending,
            TotalAmount = 99.97m,
            ShippingAddress = orderCreateDto.ShippingAddress,
            PaymentMethod = orderCreateDto.PaymentMethod,
            Notes = orderCreateDto.Notes,
            OrderItems = new List<OrderItem>
            {
                new()
                {
                    Id = 1,
                    OrderId = 1,
                    BookId = 1,
                    Quantity = 2,
                    PriceAtOrder = 29.99m,
                    Book = book1
                },
                new()
                {
                    Id = 2,
                    OrderId = 1,
                    BookId = 2,
                    Quantity = 1,
                    PriceAtOrder = 39.99m,
                    Book = book2
                }
            }
        };

        var orderReadDto = new OrderReadDto
        {
            Id = 1,
            OrderNumber = "ORD-20250104-123456",
            TotalAmount = 99.97m,
            Status = OrderStatus.Pending,
            PaymentStatus = PaymentStatus.Pending,
            OrderItems = new List<OrderItemDto>
            {
                new() { BookId = 1, BookTitle = "Clean Code", Quantity = 2, PriceAtOrder = 29.99m },
                new() { BookId = 2, BookTitle = "Design Patterns", Quantity = 1, PriceAtOrder = 39.99m }
            }
        };

        _mockCartRepository.Setup(x => x.GetUserCartAsync(userId, It.IsAny<CancellationToken>())).ReturnsAsync(cart);
        _mockBookRepository
            .Setup(x => x.FindAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Book, bool>>>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Book> { book1, book2 });
        _mockOrderRepository.Setup(x => x.AddAsync(It.IsAny<Order>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
        _mockOrderItemRepository.Setup(x => x.AddAsync(It.IsAny<OrderItem>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
        _mockCartRepository.Setup(x => x.ClearCartAsync(cart.Id, It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
        _mockOrderRepository.Setup(x => x.GetOrderWithDetailsAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(createdOrder);
        _mockMapper.Setup(x => x.Map<OrderReadDto>(createdOrder)).Returns(orderReadDto);
        _mockUnitOfWork.Setup(x => x.BeginTransactionAsync()).Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
        _mockUnitOfWork.Setup(x => x.CommitTransactionAsync()).Returns(Task.CompletedTask);

        // Act
        var result = await _sut.CreateOrderFromCartAsync(userId, orderCreateDto, It.IsAny<CancellationToken>());

        // Assert
        result.Should().NotBeNull();
        result.OrderNumber.Should().Be("ORD-20250104-123456");
        result.TotalAmount.Should().Be(99.97m);
        result.OrderItems.Should().HaveCount(2);
        result.Status.Should().Be(OrderStatus.Pending);
        result.PaymentStatus.Should().Be(PaymentStatus.Pending);

        _mockOrderRepository.Verify(x => x.AddAsync(It.IsAny<Order>(), It.IsAny<CancellationToken>()), Times.Once);
        _mockOrderItemRepository.Verify(x => x.AddAsync(It.IsAny<OrderItem>(), It.IsAny<CancellationToken>()),
            Times.Exactly(2));
        _mockBookRepository.Verify(x => x.Update(book1, It.IsAny<CancellationToken>()), Times.Once);
        _mockBookRepository.Verify(x => x.Update(book2, It.IsAny<CancellationToken>()), Times.Once);
        _mockCartRepository.Verify(x => x.ClearCartAsync(cart.Id, It.IsAny<CancellationToken>()), Times.Once);
        _mockUnitOfWork.Verify(x => x.CommitTransactionAsync(), Times.Once);
        _mockUnitOfWork.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Exactly(2));
    }

    [Fact]
    public async Task CreateOrderFromCartAsync_WithEmptyCart_ThrowsInvalidOperationException()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var orderCreateDto = new OrderCreateDto
        {
            ShippingAddress = "123 Main St",
            PaymentMethod = "Credit Card"
        };

        _mockCartRepository.Setup(x => x.GetUserCartAsync(userId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Cart?)null);
        _mockUnitOfWork.Setup(x => x.BeginTransactionAsync()).Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(x => x.RollbackTransactionAsync()).Returns(Task.CompletedTask);

        // Act
        var act = async () =>
            await _sut.CreateOrderFromCartAsync(userId, orderCreateDto, It.IsAny<CancellationToken>());

        // Assert
        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage(ErrorMessages.EmptyCart);

        _mockUnitOfWork.Verify(x => x.RollbackTransactionAsync(), Times.Once);
        _mockUnitOfWork.Verify(x => x.CommitTransactionAsync(), Times.Never);
        _mockOrderRepository.Verify(x => x.AddAsync(It.IsAny<Order>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CreateOrderFromCartAsync_WithCartContainingNoItems_ThrowsInvalidOperationException()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var orderCreateDto = new OrderCreateDto
        {
            ShippingAddress = "123 Main St",
            PaymentMethod = "Credit Card"
        };

        var emptyCart = new Cart
        {
            Id = 1,
            UserId = userId,
            CartItems = new List<CartItem>()
        };

        _mockCartRepository.Setup(x => x.GetUserCartAsync(userId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(emptyCart);
        _mockUnitOfWork.Setup(x => x.BeginTransactionAsync()).Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(x => x.RollbackTransactionAsync()).Returns(Task.CompletedTask);

        // Act
        var act = async () =>
            await _sut.CreateOrderFromCartAsync(userId, orderCreateDto, It.IsAny<CancellationToken>());

        // Assert
        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage(ErrorMessages.EmptyCart);

        _mockUnitOfWork.Verify(x => x.RollbackTransactionAsync(), Times.Once);
        _mockOrderRepository.Verify(x => x.AddAsync(It.IsAny<Order>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CreateOrderFromCartAsync_WithNonExistentBook_ThrowsKeyNotFoundException()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var orderCreateDto = new OrderCreateDto
        {
            ShippingAddress = "123 Main St",
            PaymentMethod = "Credit Card"
        };

        var cart = new Cart
        {
            Id = 1,
            UserId = userId,
            CartItems = new List<CartItem>
            {
                new()
                {
                    Id = 1,
                    CartId = 1,
                    BookId = 999,
                    Quantity = 2,
                    PriceAtAdd = 29.99m
                }
            }
        };

        _mockCartRepository.Setup(x => x.GetUserCartAsync(userId, It.IsAny<CancellationToken>())).ReturnsAsync(cart);
        // FindAsync returns empty list — simulates book 999 not found
        _mockBookRepository
            .Setup(x => x.FindAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Book, bool>>>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Book>());
        _mockUnitOfWork.Setup(x => x.BeginTransactionAsync()).Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(x => x.RollbackTransactionAsync()).Returns(Task.CompletedTask);

        // Act
        var act = async () =>
            await _sut.CreateOrderFromCartAsync(userId, orderCreateDto, It.IsAny<CancellationToken>());

        // Assert
        await act.Should().ThrowAsync<KeyNotFoundException>()
            .WithMessage("Book with ID 999 not found");

        _mockUnitOfWork.Verify(x => x.RollbackTransactionAsync(), Times.Once);
        _mockOrderRepository.Verify(x => x.AddAsync(It.IsAny<Order>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CreateOrderFromCartAsync_WithInsufficientStock_ThrowsInvalidOperationException()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var orderCreateDto = new OrderCreateDto
        {
            ShippingAddress = "123 Main St",
            PaymentMethod = "Credit Card"
        };

        var book = new Book
        {
            Id = 1,
            Title = "Clean Code",
            Price = 29.99m,
            QuantityInStock = 1
        };

        var cart = new Cart
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
                    PriceAtAdd = 29.99m,
                    Book = book
                }
            }
        };

        _mockCartRepository.Setup(x => x.GetUserCartAsync(userId, It.IsAny<CancellationToken>())).ReturnsAsync(cart);
        _mockBookRepository
            .Setup(x => x.FindAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Book, bool>>>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Book> { book });
        _mockUnitOfWork.Setup(x => x.BeginTransactionAsync()).Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(x => x.RollbackTransactionAsync()).Returns(Task.CompletedTask);

        // Act
        var act = async () =>
            await _sut.CreateOrderFromCartAsync(userId, orderCreateDto, It.IsAny<CancellationToken>());

        // Assert
        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("Insufficient stock for book: Clean Code");

        _mockUnitOfWork.Verify(x => x.RollbackTransactionAsync(), Times.Once);
        _mockOrderRepository.Verify(x => x.AddAsync(It.IsAny<Order>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CreateOrderFromCartAsync_ReducesBookStock_Correctly()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var orderCreateDto = new OrderCreateDto
        {
            ShippingAddress = "123 Main St",
            PaymentMethod = "Credit Card"
        };

        var book = new Book
        {
            Id = 1,
            Title = "Clean Code",
            Price = 29.99m,
            QuantityInStock = 10
        };

        var cart = new Cart
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
                    Quantity = 3,
                    PriceAtAdd = 29.99m,
                    Book = book
                }
            }
        };

        var createdOrder = new Order
        {
            Id = 1,
            UserId = userId,
            OrderNumber = "ORD-20250104-123456",
            OrderItems = new List<OrderItem>()
        };

        _mockCartRepository.Setup(x => x.GetUserCartAsync(userId, It.IsAny<CancellationToken>())).ReturnsAsync(cart);
        _mockBookRepository
            .Setup(x => x.FindAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Book, bool>>>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Book> { book });
        _mockOrderRepository.Setup(x => x.AddAsync(It.IsAny<Order>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
        _mockOrderItemRepository.Setup(x => x.AddAsync(It.IsAny<OrderItem>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
        _mockCartRepository.Setup(x => x.ClearCartAsync(cart.Id, It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
        _mockOrderRepository.Setup(x => x.GetOrderWithDetailsAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(createdOrder);
        _mockMapper.Setup(x => x.Map<OrderReadDto>(createdOrder)).Returns(new OrderReadDto());
        _mockUnitOfWork.Setup(x => x.BeginTransactionAsync()).Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
        _mockUnitOfWork.Setup(x => x.CommitTransactionAsync()).Returns(Task.CompletedTask);

        // Act
        await _sut.CreateOrderFromCartAsync(userId, orderCreateDto, It.IsAny<CancellationToken>());

        // Assert
        book.QuantityInStock.Should().Be(7);
        _mockBookRepository.Verify(x => x.Update(book, It.IsAny<CancellationToken>()), Times.Once);
    }

    #endregion

    #region GetUserOrdersAsync Tests

    [Fact]
    public async Task GetUserOrdersAsync_WithExistingOrders_ReturnsPagedOrders()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var parameters = new QueryParameters
        {
            PageNumber = 1,
            PageSize = 10
        };

        var orders = new List<Order>
        {
            new()
            {
                Id = 1,
                UserId = userId,
                OrderNumber = "ORD-20250104-123456",
                TotalAmount = 99.97m,
                Status = OrderStatus.Pending,
                OrderItems = new List<OrderItem>()
            },
            new()
            {
                Id = 2,
                UserId = userId,
                OrderNumber = "ORD-20250103-654321",
                TotalAmount = 49.99m,
                Status = OrderStatus.Processing,
                OrderItems = new List<OrderItem>()
            }
        };

        var pagedOrders = new PagedResult<Order>(orders, 2, 1, 10);

        var orderDtos = new List<OrderListDto>
        {
            new()
            {
                Id = 1,
                OrderNumber = "ORD-20250104-123456",
                TotalAmount = 99.97m,
                Status = OrderStatus.Pending
            },
            new()
            {
                Id = 2,
                OrderNumber = "ORD-20250103-654321",
                TotalAmount = 49.99m,
                Status = OrderStatus.Processing
            }
        };

        _mockOrderRepository.Setup(x => x.GetUserOrdersAsync(userId, parameters, It.IsAny<CancellationToken>()))
            .ReturnsAsync(pagedOrders);
        _mockMapper.Setup(x => x.Map<IEnumerable<OrderListDto>>(orders))
            .Returns(orderDtos);

        // Act
        var result = await _sut.GetUserOrdersAsync(userId, parameters, It.IsAny<CancellationToken>());

        // Assert
        result.Should().NotBeNull();
        result.Items.Should().HaveCount(2);
        result.TotalCount.Should().Be(2);
        result.CurrentPage.Should().Be(1);
        result.PageSize.Should().Be(10);

        _mockOrderRepository.Verify(x => x.GetUserOrdersAsync(userId, parameters, It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task GetUserOrdersAsync_WithNoOrders_ReturnsEmptyPagedResult()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var parameters = new QueryParameters
        {
            PageNumber = 1,
            PageSize = 10
        };

        var emptyOrders = new List<Order>();
        var pagedOrders = new PagedResult<Order>(emptyOrders, 0, 1, 10);

        _mockOrderRepository.Setup(x => x.GetUserOrdersAsync(userId, parameters, It.IsAny<CancellationToken>()))
            .ReturnsAsync(pagedOrders);
        _mockMapper.Setup(x => x.Map<IEnumerable<OrderListDto>>(emptyOrders))
            .Returns(new List<OrderListDto>());

        // Act
        var result = await _sut.GetUserOrdersAsync(userId, parameters, It.IsAny<CancellationToken>());

        // Assert
        result.Should().NotBeNull();
        result.Items.Should().BeEmpty();
        result.TotalCount.Should().Be(0);
    }

    #endregion

    #region GetOrderByIdAsync Tests

    [Fact]
    public async Task GetOrderByIdAsync_AsUser_WithValidOrder_ReturnsOrder()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var orderId = 1;

        var order = new Order
        {
            Id = orderId,
            UserId = userId,
            OrderNumber = "ORD-20250104-123456",
            TotalAmount = 99.97m,
            Status = OrderStatus.Pending,
            OrderItems = new List<OrderItem>()
        };

        var orderDto = new OrderReadDto
        {
            Id = orderId,
            OrderNumber = "ORD-20250104-123456",
            TotalAmount = 99.97m
        };

        _mockOrderRepository.Setup(x => x.GetUserOrderByIdAsync(userId, orderId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(order);
        _mockMapper.Setup(x => x.Map<OrderReadDto>(order)).Returns(orderDto);

        // Act
        var result = await _sut.GetOrderByIdAsync(userId, orderId, It.IsAny<CancellationToken>());

        // Assert
        result.Should().NotBeNull();
        result!.Id.Should().Be(orderId);
        result.OrderNumber.Should().Be("ORD-20250104-123456");

        _mockOrderRepository.Verify(x => x.GetUserOrderByIdAsync(userId, orderId, It.IsAny<CancellationToken>()),
            Times.Once);
        _mockOrderRepository.Verify(x => x.GetOrderWithDetailsAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()),
            Times.Never);
    }

    [Fact]
    public async Task GetOrderByIdAsync_AsAdmin_WithValidOrder_ReturnsOrder()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var orderId = 1;

        var order = new Order
        {
            Id = orderId,
            UserId = Guid.NewGuid(),
            OrderNumber = "ORD-20250104-123456",
            TotalAmount = 99.97m,
            OrderItems = new List<OrderItem>()
        };

        var orderDto = new OrderReadDto
        {
            Id = orderId,
            OrderNumber = "ORD-20250104-123456"
        };

        _mockOrderRepository.Setup(x => x.GetOrderWithDetailsAsync(orderId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(order);
        _mockMapper.Setup(x => x.Map<OrderReadDto>(order)).Returns(orderDto);

        // Act
        var result = await _sut.GetOrderByIdAsync(userId, orderId, It.IsAny<CancellationToken>(), true);

        // Assert
        result.Should().NotBeNull();
        result!.Id.Should().Be(orderId);

        _mockOrderRepository.Verify(x => x.GetOrderWithDetailsAsync(orderId, It.IsAny<CancellationToken>()),
            Times.Once);
        _mockOrderRepository.Verify(
            x => x.GetUserOrderByIdAsync(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<CancellationToken>()),
            Times.Never);
    }

    [Fact]
    public async Task GetOrderByIdAsync_WithNonExistentOrder_ReturnsNull()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var orderId = 999;

        _mockOrderRepository.Setup(x => x.GetUserOrderByIdAsync(userId, orderId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Order?)null);

        // Act
        var result = await _sut.GetOrderByIdAsync(userId, orderId, It.IsAny<CancellationToken>());

        // Assert
        result.Should().BeNull();

        _mockOrderRepository.Verify(x => x.GetUserOrderByIdAsync(userId, orderId, It.IsAny<CancellationToken>()),
            Times.Once);
        _mockMapper.Verify(x => x.Map<OrderReadDto>(It.IsAny<Order>()), Times.Never);
    }

    #endregion

    #region CancelOrderAsync Tests

    [Fact]
    public async Task CancelOrderAsync_WithPendingOrder_CancelsSuccessfully()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var orderId = 1;

        var book = new Book
        {
            Id = 1,
            Title = "Clean Code",
            QuantityInStock = 5
        };

        var order = new Order
        {
            Id = orderId,
            UserId = userId,
            OrderNumber = "ORD-20250104-123456",
            Status = OrderStatus.Pending,
            OrderItems = new List<OrderItem>
            {
                new()
                {
                    Id = 1,
                    OrderId = orderId,
                    BookId = 1,
                    Quantity = 3,
                    PriceAtOrder = 29.99m,
                    Book = book
                }
            }
        };

        _mockOrderRepository.Setup(x => x.GetUserOrderByIdAsync(userId, orderId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(order);
        _mockBookRepository
            .Setup(x => x.FindAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Book, bool>>>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Book> { book });
        _mockUnitOfWork.Setup(x => x.BeginTransactionAsync()).Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
        _mockUnitOfWork.Setup(x => x.CommitTransactionAsync()).Returns(Task.CompletedTask);

        // Act
        var result = await _sut.CancelOrderAsync(userId, orderId, It.IsAny<CancellationToken>());

        // Assert
        result.Should().NotBeNull();
        result.Succeeded.Should().BeTrue();
        result.Message.Should().Be("Order cancelled successfully");
        order.Status.Should().Be(OrderStatus.Cancelled);
        book.QuantityInStock.Should().Be(8);

        _mockOrderRepository.Verify(x => x.Update(order, It.IsAny<CancellationToken>()), Times.Once);
        _mockBookRepository.Verify(x => x.Update(book, It.IsAny<CancellationToken>()), Times.Once);
        _mockUnitOfWork.Verify(x => x.CommitTransactionAsync(), Times.Once);
    }

    [Fact]
    public async Task CancelOrderAsync_WithProcessingOrder_CancelsSuccessfully()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var orderId = 1;

        var order = new Order
        {
            Id = orderId,
            UserId = userId,
            Status = OrderStatus.Processing,
            OrderItems = new List<OrderItem>()
        };

        _mockOrderRepository.Setup(x => x.GetUserOrderByIdAsync(userId, orderId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(order);
        _mockUnitOfWork.Setup(x => x.BeginTransactionAsync()).Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
        _mockUnitOfWork.Setup(x => x.CommitTransactionAsync()).Returns(Task.CompletedTask);

        // Act
        var result = await _sut.CancelOrderAsync(userId, orderId, It.IsAny<CancellationToken>());

        // Assert
        result.Succeeded.Should().BeTrue();
        order.Status.Should().Be(OrderStatus.Cancelled);
    }

    [Fact]
    public async Task CancelOrderAsync_WithShippedOrder_ReturnsFailure()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var orderId = 1;

        var order = new Order
        {
            Id = orderId,
            UserId = userId,
            Status = OrderStatus.Shipped,
            OrderItems = new List<OrderItem>()
        };

        _mockOrderRepository.Setup(x => x.GetUserOrderByIdAsync(userId, orderId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(order);
        _mockUnitOfWork.Setup(x => x.BeginTransactionAsync()).Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(x => x.RollbackTransactionAsync()).Returns(Task.CompletedTask);

        // Act
        var result = await _sut.CancelOrderAsync(userId, orderId, It.IsAny<CancellationToken>());

        // Assert
        result.Should().NotBeNull();
        result.Succeeded.Should().BeFalse();
        result.Message.Should().Contain("Cannot cancel order");
        order.Status.Should().Be(OrderStatus.Shipped);

        _mockUnitOfWork.Verify(x => x.RollbackTransactionAsync(), Times.Once);
        _mockUnitOfWork.Verify(x => x.CommitTransactionAsync(), Times.Never);
        _mockOrderRepository.Verify(x => x.Update(It.IsAny<Order>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CancelOrderAsync_WithDeliveredOrder_ReturnsFailure()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var orderId = 1;

        var order = new Order
        {
            Id = orderId,
            UserId = userId,
            Status = OrderStatus.Delivered,
            OrderItems = new List<OrderItem>()
        };

        _mockOrderRepository.Setup(x => x.GetUserOrderByIdAsync(userId, orderId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(order);
        _mockUnitOfWork.Setup(x => x.BeginTransactionAsync()).Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(x => x.RollbackTransactionAsync()).Returns(Task.CompletedTask);

        // Act
        var result = await _sut.CancelOrderAsync(userId, orderId, It.IsAny<CancellationToken>());

        // Assert
        result.Succeeded.Should().BeFalse();
        order.Status.Should().Be(OrderStatus.Delivered);
    }

    [Fact]
    public async Task CancelOrderAsync_WithNonExistentOrder_ReturnsFailure()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var orderId = 999;

        _mockOrderRepository.Setup(x => x.GetUserOrderByIdAsync(userId, orderId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Order?)null);
        _mockUnitOfWork.Setup(x => x.BeginTransactionAsync()).Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(x => x.RollbackTransactionAsync()).Returns(Task.CompletedTask);

        // Act
        var result = await _sut.CancelOrderAsync(userId, orderId, It.IsAny<CancellationToken>());

        // Assert
        result.Should().NotBeNull();
        result.Succeeded.Should().BeFalse();
        result.Message.Should().Be(ErrorMessages.OrderNotFound);

        _mockUnitOfWork.Verify(x => x.RollbackTransactionAsync(), Times.Once);
        _mockOrderRepository.Verify(x => x.Update(It.IsAny<Order>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task CancelOrderAsync_RestoresStockForMultipleItems()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var orderId = 1;

        var book1 = new Book { Id = 1, QuantityInStock = 5 };
        var book2 = new Book { Id = 2, QuantityInStock = 10 };

        var order = new Order
        {
            Id = orderId,
            UserId = userId,
            Status = OrderStatus.Pending,
            OrderItems = new List<OrderItem>
            {
                new() { BookId = 1, Quantity = 2, Book = book1 },
                new() { BookId = 2, Quantity = 3, Book = book2 }
            }
        };

        _mockOrderRepository.Setup(x => x.GetUserOrderByIdAsync(userId, orderId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(order);
        _mockBookRepository
            .Setup(x => x.FindAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Book, bool>>>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Book> { book1, book2 });
        _mockUnitOfWork.Setup(x => x.BeginTransactionAsync()).Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
        _mockUnitOfWork.Setup(x => x.CommitTransactionAsync()).Returns(Task.CompletedTask);

        // Act
        var result = await _sut.CancelOrderAsync(userId, orderId, It.IsAny<CancellationToken>());

        // Assert
        result.Succeeded.Should().BeTrue();
        book1.QuantityInStock.Should().Be(7);
        book2.QuantityInStock.Should().Be(13);

        _mockBookRepository.Verify(x => x.Update(book1, It.IsAny<CancellationToken>()), Times.Once);
        _mockBookRepository.Verify(x => x.Update(book2, It.IsAny<CancellationToken>()), Times.Once);
    }

    #endregion

    #region UpdateOrderStatusAsync Tests

    [Fact]
    public async Task UpdateOrderStatusAsync_WithValidOrder_UpdatesStatusSuccessfully()
    {
        // Arrange
        var orderId = 1;
        var updateDto = new OrderUpdateStatusDto
        {
            Status = OrderStatus.Shipped,
            Notes = "Order shipped via FedEx"
        };

        var order = new Order
        {
            Id = orderId,
            Status = OrderStatus.Processing,
            OrderItems = new List<OrderItem>()
        };

        _mockOrderRepository.Setup(x => x.GetOrderWithDetailsAsync(orderId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(order);
        _mockUnitOfWork.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        // Act
        var result = await _sut.UpdateOrderStatusAsync(orderId, updateDto, It.IsAny<CancellationToken>());

        // Assert
        result.Should().NotBeNull();
        result.Succeeded.Should().BeTrue();
        result.Message.Should().Be("Order status updated successfully");
        order.Status.Should().Be(OrderStatus.Shipped);
        order.Notes.Should().Be("Order shipped via FedEx");

        _mockOrderRepository.Verify(x => x.Update(order, It.IsAny<CancellationToken>()), Times.Once);
        _mockUnitOfWork.Verify(x => x.SaveChangesAsync(default), Times.Once);
    }

    [Fact]
    public async Task UpdateOrderStatusAsync_WithNonExistentOrder_ReturnsFailure()
    {
        // Arrange
        var orderId = 999;
        var updateDto = new OrderUpdateStatusDto
        {
            Status = OrderStatus.Shipped
        };

        _mockOrderRepository.Setup(x => x.GetOrderWithDetailsAsync(orderId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Order?)null);

        // Act
        var result = await _sut.UpdateOrderStatusAsync(orderId, updateDto, It.IsAny<CancellationToken>());

        // Assert
        result.Should().NotBeNull();
        result.Succeeded.Should().BeFalse();
        result.Message.Should().Be(ErrorMessages.OrderNotFound);

        _mockOrderRepository.Verify(x => x.Update(It.IsAny<Order>(), It.IsAny<CancellationToken>()), Times.Never);
        _mockUnitOfWork.Verify(x => x.SaveChangesAsync(default), Times.Never);
    }

    [Fact]
    public async Task UpdateOrderStatusAsync_WithoutNotes_UpdatesStatusOnly()
    {
        // Arrange
        var orderId = 1;
        var updateDto = new OrderUpdateStatusDto
        {
            Status = OrderStatus.Delivered
        };

        var order = new Order
        {
            Id = orderId,
            Status = OrderStatus.Shipped,
            Notes = "Previous notes",
            OrderItems = new List<OrderItem>()
        };

        _mockOrderRepository.Setup(x => x.GetOrderWithDetailsAsync(orderId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(order);
        _mockUnitOfWork.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        // Act
        var result = await _sut.UpdateOrderStatusAsync(orderId, updateDto, It.IsAny<CancellationToken>());

        // Assert
        result.Succeeded.Should().BeTrue();
        order.Status.Should().Be(OrderStatus.Delivered);
        order.Notes.Should().Be("Previous notes");
    }

    #endregion

    #region UpdatePaymentStatusAsync Tests

    [Fact]
    public async Task UpdatePaymentStatusAsync_WithValidOrder_UpdatesPaymentStatusSuccessfully()
    {
        // Arrange
        var orderId = 1;
        var updateDto = new PaymentUpdateStatusDto
        {
            PaymentStatus = PaymentStatus.Completed
        };

        var order = new Order
        {
            Id = orderId,
            PaymentStatus = PaymentStatus.Pending
        };

        _mockOrderRepository.Setup(x => x.GetByIdAsync(orderId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(order);
        _mockUnitOfWork.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        // Act
        var result = await _sut.UpdatePaymentStatusAsync(orderId, updateDto, It.IsAny<CancellationToken>());

        // Assert
        result.Should().NotBeNull();
        result.Succeeded.Should().BeTrue();
        result.Message.Should().Be("Payment status updated successfully");
        order.PaymentStatus.Should().Be(PaymentStatus.Completed);

        _mockOrderRepository.Verify(x => x.Update(order, It.IsAny<CancellationToken>()), Times.Once);
        _mockUnitOfWork.Verify(x => x.SaveChangesAsync(default), Times.Once);
    }

    [Fact]
    public async Task UpdatePaymentStatusAsync_WithNonExistentOrder_ReturnsFailure()
    {
        // Arrange
        var orderId = 999;
        var updateDto = new PaymentUpdateStatusDto
        {
            PaymentStatus = PaymentStatus.Completed
        };

        _mockOrderRepository.Setup(x => x.GetByIdAsync(orderId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Order?)null);

        // Act
        var result = await _sut.UpdatePaymentStatusAsync(orderId, updateDto, It.IsAny<CancellationToken>());

        // Assert
        result.Should().NotBeNull();
        result.Succeeded.Should().BeFalse();
        result.Message.Should().Be(ErrorMessages.OrderNotFound);

        _mockOrderRepository.Verify(x => x.Update(It.IsAny<Order>(), It.IsAny<CancellationToken>()), Times.Never);
        _mockUnitOfWork.Verify(x => x.SaveChangesAsync(default), Times.Never);
    }

    [Fact]
    public async Task UpdatePaymentStatusAsync_ToRefunded_UpdatesSuccessfully()
    {
        // Arrange
        var orderId = 1;
        var updateDto = new PaymentUpdateStatusDto
        {
            PaymentStatus = PaymentStatus.Refunded
        };

        var order = new Order
        {
            Id = orderId,
            PaymentStatus = PaymentStatus.Completed
        };

        _mockOrderRepository.Setup(x => x.GetByIdAsync(orderId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(order);
        _mockUnitOfWork.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        // Act
        var result = await _sut.UpdatePaymentStatusAsync(orderId, updateDto, It.IsAny<CancellationToken>());

        // Assert
        result.Succeeded.Should().BeTrue();
        order.PaymentStatus.Should().Be(PaymentStatus.Refunded);
    }

    #endregion
}