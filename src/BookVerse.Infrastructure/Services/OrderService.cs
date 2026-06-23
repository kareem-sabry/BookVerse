using AutoMapper;
using BookVerse.Application.Dtos.Order;
using BookVerse.Application.Dtos.User;
using BookVerse.Application.Interfaces;
using BookVerse.Core.Constants;
using BookVerse.Core.Entities;
using BookVerse.Core.Enums;
using BookVerse.Core.Models;
using Microsoft.Extensions.Logging;
using BookVerse.Core.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BookVerse.Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly ILogger<OrderService> _logger;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILogger<OrderService> logger,
        IDateTimeProvider dateTimeProvider)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<OrderReadDto> CreateOrderFromCartAsync(Guid userId, OrderCreateDto orderCreateDto,
        CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync();

        // Get user's cart
        var cart = await _unitOfWork.Carts.GetUserCartAsync(userId, cancellationToken);
        if (cart == null || !cart.CartItems.Any())
        {
            _logger.LogWarning("Attempted to create order with empty cart for user: {UserId}", userId);
            await _unitOfWork.RollbackTransactionAsync();
            throw new ValidationException(ErrorMessages.EmptyCart);
        }

        // Single bulk fetch of all books needed for this order.
        // Used for both stock validation and stock deduction — eliminates N+1.
        var bookIds = cart.CartItems.Select(ci => ci.BookId).ToList();
        var books = (await _unitOfWork.Books.FindAsync(b => bookIds.Contains(b.Id), cancellationToken))
            .ToDictionary(b => b.Id);

        // Validate stock availability for all items before creating anything
        foreach (var cartItem in cart.CartItems)
        {
            if (!books.TryGetValue(cartItem.BookId, out var book))
            {
                _logger.LogWarning("Book not found: {BookId}", cartItem.BookId);
                await _unitOfWork.RollbackTransactionAsync();
                throw new NotFoundException($"Book with ID {cartItem.BookId} not found");
            }

            if (book.QuantityInStock < cartItem.Quantity)
            {
                _logger.LogWarning(
                    "Insufficient stock for book: {BookId}. Requested: {Requested}, Available: {Available}",
                    cartItem.BookId, cartItem.Quantity, book.QuantityInStock);
                await _unitOfWork.RollbackTransactionAsync();
                throw new ValidationException($"Insufficient stock for book: {book.Title}");
            }
        }

        var totalAmount =
            cart.CartItems.Sum(ci => books.TryGetValue(ci.BookId, out var b) ? b.Price * ci.Quantity : 0m);

        // Create order
        var order = new Order
        {
            UserId = userId,
            OrderNumber = GenerateOrderNumber(),
            OrderDate = _dateTimeProvider.UtcNow,
            Status = OrderStatus.Pending,
            ShippingAddress = orderCreateDto.ShippingAddress,
            PaymentMethod = orderCreateDto.PaymentMethod,
            PaymentStatus = PaymentStatus.Pending,
            Notes = orderCreateDto.Notes,
            TotalAmount = totalAmount
        };

        await _unitOfWork.Orders.AddAsync(order, cancellationToken);
        try
        {
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException ex)
            when (ex.InnerException is SqlException { Number: 2627 or 2601 })
        {
            // 2627 = unique key / PK violation, 2601 = duplicate key in unique index
            _logger.LogWarning("OrderNumber collision detected for {OrderNumber} — rolling back and retrying",
                order.OrderNumber);
            await _unitOfWork.RollbackTransactionAsync();
            await _unitOfWork.BeginTransactionAsync();
            order.OrderNumber = GenerateOrderNumber();
            await _unitOfWork.Orders.AddAsync(order, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        // Create order items and deduct stock using the same bulk-fetched dictionary
        foreach (var cartItem in cart.CartItems)
        {
            var currentPrice = books[cartItem.BookId].Price;

            var orderItem = new OrderItem
            {
                OrderId = order.Id,
                BookId = cartItem.BookId,
                Quantity = cartItem.Quantity,
                PriceAtOrder = currentPrice
            };

            await _unitOfWork.OrderItems.AddAsync(orderItem, cancellationToken);

            if (books.TryGetValue(cartItem.BookId, out var book))
            {
                book.QuantityInStock -= cartItem.Quantity;
                _unitOfWork.Books.Update(book);
            }
        }

        // Clear the cart
        await _unitOfWork.Carts.ClearCartAsync(cart.Id, cancellationToken);

        try
        {
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException ex)
        {
            // Rowversion conflict — another transaction modified a book between our read and write.
            // Re-fetch fresh stock data to determine the actual cause before surfacing an error.
            _logger.LogWarning(ex, "Rowversion conflict during stock deduction for user {UserId} — revalidating stock",
                userId);
            await _unitOfWork.RollbackTransactionAsync();

            var freshBooks = (await _unitOfWork.Books.FindAsync(b => bookIds.Contains(b.Id), cancellationToken))
                .ToDictionary(b => b.Id);

            foreach (var cartItem in cart.CartItems)
            {
                if (!freshBooks.TryGetValue(cartItem.BookId, out var book) ||
                    book.QuantityInStock < cartItem.Quantity)
                    throw new ValidationException(ErrorMessages.InsufficientStock);
            }

            // Stock is still sufficient — conflict was transient; surface as retriable
            throw new ConflictException("Order could not be placed due to concurrent activity. Please try again.");
        }

        await _unitOfWork.CommitTransactionAsync();
        _logger.LogInformation("Order created successfully: {OrderNumber} for user: {UserId}", order.OrderNumber,
            userId);

        // Retrieve the complete order with details
        var createdOrder = await _unitOfWork.Orders.GetOrderWithDetailsAsync(order.Id, cancellationToken);
        return _mapper.Map<OrderReadDto>(createdOrder!);
    }

    public async Task<PagedResult<OrderListDto>> GetUserOrdersAsync(Guid userId, QueryParameters parameters,
        CancellationToken cancellationToken)
    {
        var pagedOrders = await _unitOfWork.Orders.GetUserOrdersAsync(userId, parameters, cancellationToken);
        var orderDtos = _mapper.Map<IEnumerable<OrderListDto>>(pagedOrders.Items);

        return new PagedResult<OrderListDto>(
            orderDtos,
            pagedOrders.TotalCount,
            pagedOrders.CurrentPage,
            pagedOrders.PageSize);
    }

    public async Task<PagedResult<OrderListDto>> GetAllOrdersAsync(QueryParameters parameters,
        CancellationToken cancellationToken)
    {
        var pagedOrders = await _unitOfWork.Orders.GetAllOrdersAsync(parameters, cancellationToken);
        var orderDtos = _mapper.Map<IEnumerable<OrderListDto>>(pagedOrders.Items);

        return new PagedResult<OrderListDto>(
            orderDtos,
            pagedOrders.TotalCount,
            pagedOrders.CurrentPage,
            pagedOrders.PageSize);
    }

    public async Task<OrderReadDto?> GetOrderByIdAsync(Guid userId, int orderId,
        CancellationToken cancellationToken, bool isAdmin = false)
    {
        Order? order;

        if (isAdmin)
            order = await _unitOfWork.Orders.GetOrderWithDetailsAsync(orderId, cancellationToken);
        else
            order = await _unitOfWork.Orders.GetUserOrderByIdAsync(userId, orderId, cancellationToken);

        if (order == null)
        {
            _logger.LogWarning("Order not found: {OrderId} for user: {UserId}", orderId, userId);
            return null;
        }

        return _mapper.Map<OrderReadDto>(order);
    }

    public async Task<BasicResponse> CancelOrderAsync(Guid userId, int orderId, CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.Orders.GetUserOrderByIdAsync(userId, orderId, cancellationToken);
        if (order == null)
        {
            _logger.LogWarning("Order not found: {OrderId} for user: {UserId}", orderId, userId);
            throw new NotFoundException(ErrorMessages.OrderNotFound);
        }

        if (order.Status != OrderStatus.Pending && order.Status != OrderStatus.Processing)
        {
            _logger.LogWarning("Cannot cancel order {OrderId} with status: {Status}", orderId, order.Status);
            return new BasicResponse
            {
                Succeeded = false,
                Message = $"{ErrorMessages.CannotCancelOrderWithStatus}{order.Status}"
            };
        }

        await _unitOfWork.BeginTransactionAsync();
        try
        {
            order.Status = OrderStatus.Cancelled;
            _unitOfWork.Orders.Update(order);

            var bookIdsToRestore = order.OrderItems.Select(oi => oi.BookId).ToList();
            var booksToRestore =
                (await _unitOfWork.Books.FindAsync(b => bookIdsToRestore.Contains(b.Id), cancellationToken))
                .ToDictionary(b => b.Id);

            foreach (var orderItem in order.OrderItems)
            {
                if (booksToRestore.TryGetValue(orderItem.BookId, out var book))
                {
                    book.QuantityInStock += orderItem.Quantity;
                    _unitOfWork.Books.Update(book);
                }
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _unitOfWork.CommitTransactionAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to cancel order {OrderId} for user {UserId}", orderId, userId);
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }

        _logger.LogInformation("Order cancelled successfully: {OrderId}", orderId);

        return new BasicResponse
        {
            Succeeded = true,
            Message = SuccessMessages.OrderCancelled
        };
    }

    public async Task<BasicResponse> UpdateOrderStatusAsync(int orderId, OrderUpdateStatusDto updateDto,
        CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.Orders.GetOrderWithDetailsAsync(orderId, cancellationToken);
        if (order == null)
        {
            _logger.LogWarning("Order not found: {OrderId}", orderId);
            return new BasicResponse { Succeeded = false, Message = ErrorMessages.OrderNotFound };
        }

        // Enforce forward-only transitions via an explicit allowlist — mirrors payment status logic.
        var isValidTransition = (order.Status, updateDto.Status) switch
        {
            (OrderStatus.Pending, OrderStatus.Processing) => true,
            (OrderStatus.Processing, OrderStatus.Shipped) => true,
            (OrderStatus.Shipped, OrderStatus.Delivered) => true,
            (OrderStatus.Pending, OrderStatus.Cancelled) => true,
            (OrderStatus.Processing, OrderStatus.Cancelled) => true,
            _ => false
        };
        if (!isValidTransition)
            throw new ConflictException(
                $"{ErrorMessages.CannotUpdateTerminalOrderStatus}: {order.Status} → {updateDto.Status}");

        order.Status = updateDto.Status;
        if (!string.IsNullOrWhiteSpace(updateDto.Notes)) order.Notes = updateDto.Notes;

        _unitOfWork.Orders.Update(order);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Order status updated: {OrderId} to {Status}", orderId, updateDto.Status);
        return new BasicResponse { Succeeded = true, Message = SuccessMessages.OrderStatusUpdated };
    }

    public async Task<BasicResponse> UpdatePaymentStatusAsync(int orderId, PaymentUpdateStatusDto updateDto,
        CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(orderId, cancellationToken);
        if (order == null)
        {
            _logger.LogWarning("Order not found: {OrderId}", orderId);
            return new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.OrderNotFound
            };
        }

        // Enforce valid payment status transitions.
        // Completed and Failed are terminal — only Refunded is a valid follow-on from Completed.
        var isValidTransition = (order.PaymentStatus, updateDto.PaymentStatus) switch
        {
            (PaymentStatus.Pending, PaymentStatus.Completed) => true,
            (PaymentStatus.Pending, PaymentStatus.Failed) => true,
            (PaymentStatus.Completed, PaymentStatus.Refunded) => true,
            _ => false
        };

        if (!isValidTransition)
        {
            _logger.LogWarning(
                "Invalid payment status transition on order {OrderId}: {From} -> {To}",
                orderId, order.PaymentStatus, updateDto.PaymentStatus);
            throw new ConflictException(
                $"Cannot transition payment status from {order.PaymentStatus} to {updateDto.PaymentStatus}.");
        }

        var previousPaymentStatus = order.PaymentStatus;

        order.PaymentStatus = updateDto.PaymentStatus;
        _unitOfWork.Orders.Update(order);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Payment status updated: {OrderId} from {From} to {To}",
            orderId, previousPaymentStatus, updateDto.PaymentStatus);

        return new BasicResponse
        {
            Succeeded = true,
            Message = SuccessMessages.PaymentStatusUpdated
        };
    }

    private string GenerateOrderNumber()
    {
        // Format: ORD-YYYYMMDD-XXXXXX (e.g., ORD-20250103-123456)
        var timestamp = _dateTimeProvider.UtcNow.ToString("yyyyMMdd");
        var random = Random.Shared.Next(100000, 999999);
        return $"ORD-{timestamp}-{random}";
    }
}