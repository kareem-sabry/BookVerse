using BookVerse.Application.Dtos.Book;
using BookVerse.Core.Models;

namespace BookVerse.Application.Interfaces;

public interface IBooksService
{
    Task<PagedResult<BookReadDto>> GetPagedAsync(BookQueryParameters parameters,
        CancellationToken cancellationToken = default);

    Task<BookReadDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<BookReadDto> CreateAsync(BookCreateDto bookDto, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(int id, BookUpdateDto bookDto, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}