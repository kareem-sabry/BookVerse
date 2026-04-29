using BookVerse.Application.Interfaces;
using BookVerse.Core.Entities;
using BookVerse.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookVerse.Infrastructure.Repositories;

public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{
    public AuthorRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Author?> GetByNameAsync(string firstName, string lastName, CancellationToken cancellationToken)
    {
        return await _dbSet.AsNoTracking()
            .Include(a => a.BookAuthors)
            .ThenInclude(ba => ba.Book)
            .FirstOrDefaultAsync(a => a.FirstName == firstName && a.LastName == lastName,
                cancellationToken: cancellationToken);
    }

    public override async Task<Author?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbSet
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
    }

    public async Task<Author?> GetByIdWithBooksAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(a => a.BookAuthors)
            .ThenInclude(ba => ba.Book)
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
    }
}