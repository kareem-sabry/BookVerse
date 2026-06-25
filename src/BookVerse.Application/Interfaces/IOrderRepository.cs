using BookVerse.Core.Entities;
using BookVerse.Core.Models;

namespace BookVerse.Application.Interfaces;

public interface IOrderRepository : IGenericRepository<Order>
{
    Task<Order?> GetOrderWithDetailsAsync(int orderId, CancellationToken cancellationToken = default);

    Task<PagedResult<Order>> GetUserOrdersAsync(Guid userId, QueryParameters parameters,
        CancellationToken cancellationToken = default);

    Task<PagedResult<Order>> GetAllOrdersAsync(QueryParameters parameters,
        CancellationToken cancellationToken = default);

    Task<Order?> GetUserOrderByIdAsync(Guid userId, int orderId, CancellationToken cancellationToken = default);
    Task<bool> OrderExistsForUserAsync(Guid userId, int orderId, CancellationToken cancellationToken = default);

    Task<Order?> GetByStripePaymentIntentIdAsync(string paymentIntentId, CancellationToken cancellationToken = default);
}