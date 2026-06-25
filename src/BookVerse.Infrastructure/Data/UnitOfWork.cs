using BookVerse.Application.Interfaces;
using BookVerse.Core.Entities;
using BookVerse.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
namespace BookVerse.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private IAuthorRepository? _authorRepository;

    private IBookRepository? _bookRepository;

    private ICartRepository? _cartRepository;
    private ICategoryRepository? _categoryRepository;
    private IGenericRepository<OrderItem>? _orderItemRepository;
    private IOrderRepository? _orderRepository;
    private IDbContextTransaction? _transaction;
    private IUserRepository? _userRepository;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IUserRepository Users => _userRepository ??= new UserRepository(_context);

    public IBookRepository Books => _bookRepository ??= new BookRepository(_context);

    public IAuthorRepository Authors => _authorRepository ??= new AuthorRepository(_context);

    public ICategoryRepository Categories => _categoryRepository ??= new CategoryRepository(_context);
    public ICartRepository Carts => _cartRepository ??= new CartRepository(_context);
    public IOrderRepository Orders => _orderRepository ??= new OrderRepository(_context);

    public IGenericRepository<OrderItem> OrderItems =>
        _orderItemRepository ??= new GenericRepository<OrderItem>(_context);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        try
        {
            if (_transaction != null) await _transaction.CommitAsync();
        }
        catch
        {
            await RollbackTransactionAsync();
            throw;
        }
        finally
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }
    }

    public async Task RollbackTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task<TResult> ExecuteInTransactionAsync<TResult>(Func<Task<TResult>> operation)
    {
        var strategy = _context.Database.CreateExecutionStrategy();
        return await strategy.ExecuteAsync(operation);
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _context.Dispose();
    }
}