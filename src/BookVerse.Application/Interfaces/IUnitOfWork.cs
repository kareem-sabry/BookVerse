using BookVerse.Core.Entities;

namespace BookVerse.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IBookRepository Books { get; }
    IAuthorRepository Authors { get; }
    ICategoryRepository Categories { get; }
    ICartRepository Carts { get; }
    IOrderRepository Orders { get; }
    IUserRepository Users { get; }
    IGenericRepository<OrderItem> OrderItems { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();

    /// <summary>
    /// Runs an operation that manages its own explicit transaction (via BeginTransactionAsync /
    /// CommitTransactionAsync) through the database's execution strategy, so the whole operation
    /// can be retried as a unit on a transient SQL error. Any method that calls
    /// BeginTransactionAsync directly must be wrapped in this once retry-on-failure is enabled -
    /// EF Core throws if a transaction starts outside a retry-aware execution strategy.
    /// </summary>
    Task<TResult> ExecuteInTransactionAsync<TResult>(Func<Task<TResult>> operation);
}