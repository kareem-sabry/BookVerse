using System.Linq.Dynamic.Core;
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


    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
    }

    public virtual async Task<Core.Models.PagedResult<T>> GetPagedAsync(QueryParameters parameters)
    {
        var query = _dbSet.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(parameters.SearchTerm)) query = ApplySearch(query, parameters.SearchTerm);

        var totalCount = await query.CountAsync();

        if (!string.IsNullOrWhiteSpace(parameters.SortBy))
            query = ApplySorting(query, parameters.SortBy, parameters.SortDescending);

        var items = await query
            .Skip((parameters.PageNumber - 1) * parameters.PageSize)
            .Take(parameters.PageSize)
            .ToListAsync();

        return new Core.Models.PagedResult<T>(items, totalCount, parameters.PageNumber, parameters.PageSize);
    }

    public virtual async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public virtual void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public virtual void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
    }

    public virtual async Task<bool> ExistsAsync(int id)
    {
        return await _dbSet.AnyAsync(e => EF.Property<int>(e, "Id") == id);
    }

    public virtual async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
    {
        return predicate == null
            ? await _dbSet.CountAsync()
            : await _dbSet.CountAsync(predicate);
    }

    protected virtual IQueryable<T> ApplySearch(IQueryable<T> query, string searchTerm)
    {
        return query;
    }

    protected virtual IQueryable<T> ApplySorting(IQueryable<T> query, string sortBy, bool descending)
    {
        var orderBy = descending ? $"{sortBy} descending" : sortBy;
        return query.OrderBy(orderBy);
    }
}