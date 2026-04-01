using BookVerse.Application.Dtos.Category;
using BookVerse.Core.Models;

namespace BookVerse.Application.Interfaces;

public interface ICategoryService
{
    Task<PagedResult<CategoryListDto>> GetPagedAsync(QueryParameters parameters,
        CancellationToken cancellationToken = default);

    Task<CategoryReadDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<CategoryReadDto> CreateAsync(CategoryCreateDto categoryDto, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(int id, CategoryUpdateDto categoryDto, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}