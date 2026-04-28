using BookVerse.Core.Entities;

namespace BookVerse.Application.Interfaces;

public interface IAuthorRepository : IGenericRepository<Author>
{
    Task<Author?> GetByNameAsync(string firstName, string lastName, CancellationToken cancellationToken = default);
}