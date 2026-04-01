using BookVerse.Application.Dtos.Order;
using BookVerse.Application.Dtos.User;
using BookVerse.Core.Models;

namespace BookVerse.Application.Interfaces;

public interface IOrderService
{
    Task<OrderReadDto> CreateOrderFromCartAsync(Guid userId, OrderCreateDto orderCreateDto,
        CancellationToken cancellationToken = default);

    Task<PagedResult<OrderListDto>> GetUserOrdersAsync(Guid userId, QueryParameters parameters,
        CancellationToken cancellationToken = default);

    Task<PagedResult<OrderListDto>> GetAllOrdersAsync(QueryParameters parameters,
        CancellationToken cancellationToken = default);

    Task<OrderReadDto?> GetOrderByIdAsync(Guid userId, int orderId,
        CancellationToken cancellationToken, bool isAdmin = false);

    Task<BasicResponse> CancelOrderAsync(Guid userId, int orderId, CancellationToken cancellationToken = default);

    Task<BasicResponse> UpdateOrderStatusAsync(int orderId, OrderUpdateStatusDto updateDto,
        CancellationToken cancellationToken = default);

    Task<BasicResponse> UpdatePaymentStatusAsync(int orderId, PaymentUpdateStatusDto updateDto,
        CancellationToken cancellationToken = default);
}