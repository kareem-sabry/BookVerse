using AutoMapper;
using BookVerse.Application.Dtos.Order;
using BookVerse.Application.Dtos.User;
using BookVerse.Application.Interfaces;
using BookVerse.Core.Constants;
using BookVerse.Core.Entities;
using BookVerse.Core.Enums;
using BookVerse.Core.Models;
using Microsoft.Extensions.Logging;

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

    public async Task<OrderReadDto> CreateOrderFromCartAsync(Guid userId, OrderCreateDto orderCreateDto)
    {
        await _unitOfWork.BeginTransactionAsync();

        // Get user's cart
        var cart = await _unitOfWork.Carts.GetUserCartAsync(userId);
        if (cart == null || !cart.CartItems.Any())
        {
            _logger.LogWarning("Attempted to create order with empty cart for user: {UserId}", userId);
            await _unitOfWork.RollbackTransactionAsync();
            throw new InvalidOperationException(ErrorMessages.EmptyCart);
        }

        // Validate stock availability for all items
        foreach (var cartItem in cart.CartItems)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(cartItem.BookId);
            if (book == null)
            {
                _logger.LogWarning("Book not found: {BookId}", cartItem.BookId);
                await _unitOfWork.RollbackTransactionAsync();
                throw new KeyNotFoundException($"Book with ID {cartItem.BookId} not found");
            }

            if (book.QuantityInStock < cartItem.Quantity)
            {
                _logger.LogWarning(
                    "Insufficient stock for book: {BookId}. Requested: {Requested}, Available: {Available}",
                    cartItem.BookId, cartItem.Quantity, book.QuantityInStock);
                await _unitOfWork.RollbackTransactionAsync();
                throw new InvalidOperationException($"Insufficient stock for book: {book.Title}");
            }
        }

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
            TotalAmount = cart.CartItems.Sum(ci => ci.PriceAtAdd * ci.Quantity)
        };

        await _unitOfWork.Orders.AddAsync(order);
        await _unitOfWork.SaveChangesAsync();

        // Create order items and update book stock
        foreach (var cartItem in cart.CartItems)
        {
            var orderItem = new OrderItem
            {
                OrderId = order.Id,
                BookId = cartItem.BookId,
                Quantity = cartItem.Quantity,
                PriceAtOrder = cartItem.PriceAtAdd
            };

            await _unitOfWork.OrderItems.AddAsync(orderItem);

            // Reduce book stock
            var book = await _unitOfWork.Books.GetByIdAsync(cartItem.BookId);
            if (book != null)
            {
                book.QuantityInStock -= cartItem.Quantity;
                _unitOfWork.Books.Update(book);
            }
        }

        // Clear the cart
        await _unitOfWork.Carts.ClearCartAsync(cart.Id);

        await _unitOfWork.SaveChangesAsync();
        await _unitOfWork.CommitTransactionAsync();

        _logger.LogInformation("Order created successfully: {OrderNumber} for user: {UserId}", order.OrderNumber,
            userId);

        // Retrieve the complete order with details
        var createdOrder = await _unitOfWork.Orders.GetOrderWithDetailsAsync(order.Id);
        return _mapper.Map<OrderReadDto>(createdOrder!);
    }

    public async Task<PagedResult<OrderListDto>> GetUserOrdersAsync(Guid userId, QueryParameters parameters)
    {
        var pagedOrders = await _unitOfWork.Orders.GetUserOrdersAsync(userId, parameters);
        var orderDtos = _mapper.Map<IEnumerable<OrderListDto>>(pagedOrders.Items);

        return new PagedResult<OrderListDto>(
            orderDtos,
            pagedOrders.TotalCount,
            pagedOrders.CurrentPage,
            pagedOrders.PageSize);
    }

    public async Task<PagedResult<OrderListDto>> GetAllOrdersAsync(QueryParameters parameters)
    {
        var pagedOrders = await _unitOfWork.Orders.GetAllOrdersAsync(parameters);
        var orderDtos = _mapper.Map<IEnumerable<OrderListDto>>(pagedOrders.Items);

        return new PagedResult<OrderListDto>(
            orderDtos,
            pagedOrders.TotalCount,
            pagedOrders.CurrentPage,
            pagedOrders.PageSize);
    }

    public async Task<OrderReadDto?> GetOrderByIdAsync(Guid userId, int orderId, bool isAdmin = false)
    {
        Order? order;

        if (isAdmin)
            order = await _unitOfWork.Orders.GetOrderWithDetailsAsync(orderId);
        else
            order = await _unitOfWork.Orders.GetUserOrderByIdAsync(userId, orderId);

        if (order == null)
        {
            _logger.LogWarning("Order not found: {OrderId} for user: {UserId}", orderId, userId);
            return null;
        }

        return _mapper.Map<OrderReadDto>(order);
    }

    public async Task<BasicResponse> CancelOrderAsync(Guid userId, int orderId)
    {
        await _unitOfWork.BeginTransactionAsync();

        var order = await _unitOfWork.Orders.GetUserOrderByIdAsync(userId, orderId);
        if (order == null)
        {
            _logger.LogWarning("Order not found: {OrderId} for user: {UserId}", orderId, userId);
            await _unitOfWork.RollbackTransactionAsync();
            return new BasicResponse
            {
                Succeeded = false,
                Message = "Order not found"
            };
        }

        // Only pending or processing orders can be cancelled
        if (order.Status != OrderStatus.Pending && order.Status != OrderStatus.Processing)
        {
            _logger.LogWarning("Cannot cancel order with status: {Status}", order.Status);
            await _unitOfWork.RollbackTransactionAsync();
            return new BasicResponse
            {
                Succeeded = false,
                Message = $"Cannot cancel order with status: {order.Status}"
            };
        }

        // Update order status
        order.Status = OrderStatus.Cancelled;
        _unitOfWork.Orders.Update(order);

        // Restore book stock
        foreach (var orderItem in order.OrderItems)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(orderItem.BookId);
            if (book != null)
            {
                book.QuantityInStock += orderItem.Quantity;
                _unitOfWork.Books.Update(book);
            }
        }

        await _unitOfWork.SaveChangesAsync();
        await _unitOfWork.CommitTransactionAsync();

        _logger.LogInformation("Order cancelled successfully: {OrderId}", orderId);

        return new BasicResponse
        {
            Succeeded = true,
            Message = "Order cancelled successfully"
        };
    }

    public async Task<BasicResponse> UpdateOrderStatusAsync(int orderId, OrderUpdateStatusDto updateDto)
    {
        var order = await _unitOfWork.Orders.GetOrderWithDetailsAsync(orderId);
        if (order == null)
        {
            _logger.LogWarning("Order not found: {OrderId}", orderId);
            return new BasicResponse
            {
                Succeeded = false,
                Message = "Order not found"
            };
        }

        order.Status = updateDto.Status;
        if (!string.IsNullOrWhiteSpace(updateDto.Notes)) order.Notes = updateDto.Notes;

        _unitOfWork.Orders.Update(order);
        await _unitOfWork.SaveChangesAsync();

        _logger.LogInformation("Order status updated: {OrderId} to {Status}", orderId, updateDto.Status);

        return new BasicResponse
        {
            Succeeded = true,
            Message = "Order status updated successfully"
        };
    }

    public async Task<BasicResponse> UpdatePaymentStatusAsync(int orderId, PaymentUpdateStatusDto updateDto)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
        if (order == null)
        {
            _logger.LogWarning("Order not found: {OrderId}", orderId);
            return new BasicResponse
            {
                Succeeded = false,
                Message = "Order not found"
            };
        }

        order.PaymentStatus = updateDto.PaymentStatus;
        _unitOfWork.Orders.Update(order);
        await _unitOfWork.SaveChangesAsync();

        _logger.LogInformation("Payment status updated: {OrderId} to {Status}", orderId, updateDto.PaymentStatus);

        return new BasicResponse
        {
            Succeeded = true,
            Message = "Payment status updated successfully"
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