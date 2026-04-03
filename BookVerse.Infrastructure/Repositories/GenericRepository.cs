using System.Linq.Expressions;
using BookVerse.Application.Interfaces;
using BookVerse.Core.Models;
using BookVerse.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookVerse.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }


    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.AsNoTracking().ToListAsync(cancellationToken: cancellationToken);
    }

    public virtual async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbSet.AsNoTracking()
            .FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id, cancellationToken: cancellationToken);
    }

    public virtual async Task<Core.Models.PagedResult<T>> GetPagedAsync(QueryParameters parameters,
        CancellationToken cancellationToken)
    {
        var query = _dbSet.AsNoTracking();


        var totalCount = await query.CountAsync(cancellationToken: cancellationToken);


        var items = await query
            .Skip((parameters.PageNumber - 1) * parameters.PageSize)
            .Take(parameters.PageSize)
            .ToListAsync(cancellationToken: cancellationToken);

        return new Core.Models.PagedResult<T>(items, totalCount, parameters.PageNumber, parameters.PageSize);
    }

    public virtual async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
    }

    public virtual void Update(T entity, CancellationToken cancellationToken)
    {
        _dbSet.Update(entity);
    }

    public virtual void Delete(T entity, CancellationToken cancellationToken)
    {
        _dbSet.Remove(entity);
    }

    public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _dbSet.AsNoTracking().Where(predicate).ToListAsync(cancellationToken: cancellationToken);
    }

    public virtual async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbSet.AnyAsync(e => EF.Property<int>(e, "Id") == id, cancellationToken: cancellationToken);
    }

    public virtual async Task<int> CountAsync(CancellationToken cancellationToken,
        Expression<Func<T, bool>>? predicate = null
    )
    {
        return predicate == null
            ? await _dbSet.CountAsync(cancellationToken: cancellationToken)
            : await _dbSet.CountAsync(predicate, cancellationToken: cancellationToken);
    }
}