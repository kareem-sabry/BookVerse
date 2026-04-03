using BookVerse.Application.Interfaces;
using BookVerse.Core.Entities;
using BookVerse.Core.Models;
using BookVerse.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookVerse.Infrastructure.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Order?> GetOrderWithDetailsAsync(int orderId, CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Book)
            .Include(o => o.User)
            .FirstOrDefaultAsync(o => o.Id == orderId, cancellationToken: cancellationToken);
    }

    public async Task<PagedResult<Order>> GetUserOrdersAsync(Guid userId, QueryParameters parameters,
        CancellationToken cancellationToken)
    {
        var query = _dbSet
            .AsNoTracking()
            .Include(o => o.OrderItems)
            .Where(o => o.UserId == userId);

        if (!string.IsNullOrWhiteSpace(parameters.SearchTerm))
            query = query.Where(o =>
                o.OrderNumber.Contains(parameters.SearchTerm) ||
                (o.ShippingAddress != null && o.ShippingAddress.Contains(parameters.SearchTerm)));

        var totalCount = await query.CountAsync(cancellationToken: cancellationToken);


        query = query.OrderByDescending(o => o.OrderDate);

        var items = await query
            .Skip((parameters.PageNumber - 1) * parameters.PageSize)
            .Take(parameters.PageSize)
            .ToListAsync(cancellationToken: cancellationToken);

        return new PagedResult<Order>(items, totalCount, parameters.PageNumber, parameters.PageSize);
    }

    public async Task<PagedResult<Order>> GetAllOrdersAsync(QueryParameters parameters,
        CancellationToken cancellationToken)
    {
        IQueryable<Order> query = _dbSet
            .AsNoTracking()
            .Include(o => o.OrderItems)
            .Include(o => o.User);

        if (!string.IsNullOrWhiteSpace(parameters.SearchTerm))
        {
            var lowerSearchTerm = parameters.SearchTerm;
            query = query.Where(o =>
                o.OrderNumber.Contains(lowerSearchTerm) ||
                (o.ShippingAddress != null && o.ShippingAddress.Contains(lowerSearchTerm)) ||
                (o.User.Email != null && o.User.Email.Contains(lowerSearchTerm)) ||
                o.User.FirstName.Contains(lowerSearchTerm) ||
                o.User.LastName.Contains(lowerSearchTerm));
        }

        var totalCount = await query.CountAsync(cancellationToken: cancellationToken);

        query = query.OrderByDescending(o => o.OrderDate);

        var items = await query
            .Skip((parameters.PageNumber - 1) * parameters.PageSize)
            .Take(parameters.PageSize)
            .ToListAsync(cancellationToken: cancellationToken);

        return new PagedResult<Order>(items, totalCount, parameters.PageNumber, parameters.PageSize);
    }

    public async Task<Order?> GetUserOrderByIdAsync(Guid userId, int orderId, CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Book)
            .FirstOrDefaultAsync(o => o.Id == orderId && o.UserId == userId, cancellationToken: cancellationToken);
    }

    public async Task<bool> OrderExistsForUserAsync(Guid userId, int orderId, CancellationToken cancellationToken)
    {
        return await _dbSet.AnyAsync(o => o.Id == orderId && o.UserId == userId, cancellationToken: cancellationToken);
    }
}