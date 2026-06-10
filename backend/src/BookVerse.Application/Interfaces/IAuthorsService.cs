using BookVerse.Application.Dtos.Author;
using BookVerse.Core.Models;

namespace BookVerse.Application.Interfaces;

public interface IAuthorsService
{
    Task<PagedResult<AuthorListDto>> GetPagedAsync(QueryParameters parameters,
        CancellationToken cancellationToken = default);

    Task<AuthorReadDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<AuthorReadDto> CreateAsync(AuthorCreateDto authorDto, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(int id, AuthorUpdateDto authorDto, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}