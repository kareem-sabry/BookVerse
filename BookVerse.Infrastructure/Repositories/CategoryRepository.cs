using BookVerse.Application.Interfaces;
using BookVerse.Core.Entities;
using BookVerse.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookVerse.Infrastructure.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Category?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbSet.AsNoTracking()
            .Include(c => c.BookCategories)
            .ThenInclude(bc => bc.Book)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken: cancellationToken);
    }

    public async Task<Category?> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await _dbSet
            .Include(c => c.BookCategories)
            .ThenInclude(bc => bc.Book)
            .FirstOrDefaultAsync(c => c.Name == name, cancellationToken: cancellationToken);
    }
}