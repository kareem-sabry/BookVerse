using BookVerse.Core.Entities;

namespace BookVerse.Application.Interfaces;

public interface IAuthorRepository : IGenericRepository<Author>
{
    Task<Author?> GetByIdWithBooksAsync(int id, CancellationToken cancellationToken = default);

    Task<Author?> GetByNameAsync(string firstName, string lastName, CancellationToken cancellationToken = default);
}