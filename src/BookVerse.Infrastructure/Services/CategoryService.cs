using AutoMapper;
using BookVerse.Application.Dtos.Category;
using BookVerse.Application.Interfaces;
using BookVerse.Core.Constants;
using BookVerse.Core.Entities;
using BookVerse.Core.Exceptions;
using BookVerse.Core.Models;
using Microsoft.Extensions.Logging;

namespace BookVerse.Infrastructure.Services;

public class CategoryService : ICategoryService
{
    private readonly ILogger<CategoryService> _logger;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CategoryService> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<PagedResult<CategoryListDto>> GetPagedAsync(QueryParameters parameters,
        CancellationToken cancellationToken)
    {
        var pagedCategories = await _unitOfWork.Categories.GetPagedAsync(parameters, cancellationToken);
        var categoryDtos = _mapper.Map<IEnumerable<CategoryListDto>>(pagedCategories.Items);

        return new PagedResult<CategoryListDto>(
            categoryDtos,
            pagedCategories.TotalCount,
            pagedCategories.CurrentPage,
            pagedCategories.PageSize
        );
    }

    public async Task<CategoryReadDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.Categories.GetByIdAsync(id, cancellationToken);
        if (category == null)
        {
            _logger.LogWarning("Category not found with ID: {CategoryId}", id);
            return null;
        }

        var dto = _mapper.Map<CategoryReadDto>(category);
        _logger.LogInformation("Retrieved category: {CategoryId}", id);

        return dto;
    }


    public async Task<CategoryReadDto> CreateAsync(CategoryCreateDto categoryDto, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(categoryDto);
        var existingCategory = await _unitOfWork.Categories.GetByNameAsync(category.Name, cancellationToken);

        if (existingCategory != null)
        {
            _logger.LogWarning("Duplicate category creation attempted: {CategoryName}", category.Name);
            throw new ConflictException(ErrorMessages.CategoryAlreadyExists);
        }

        await _unitOfWork.Categories.AddAsync(category, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Created new category: {CategoryName}", category.Name);
        return _mapper.Map<CategoryReadDto>(category);
    }

    public async Task<bool> UpdateAsync(int id, CategoryUpdateDto categoryDto, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.Categories.GetByIdAsync(id, cancellationToken);
        if (category == null)
        {
            _logger.LogWarning("Attempted to update non-existent category with ID: {CategoryId}", id);
            return false;
        }

        _mapper.Map(categoryDto, category);
        _unitOfWork.Categories.Update(category);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Updated category: {CategoryId}", id);
        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.Categories.GetByIdAsync(id, cancellationToken);
        if (category == null)
        {
            _logger.LogWarning("Attempted to delete non-existent category with ID: {CategoryId}", id);
            return false;
        }

        var hasBooks = (await _unitOfWork.Books.FindAsync(
                b => b.BookCategories.Any(bc => bc.CategoryId == id), cancellationToken))
            .Any();

        if (hasBooks)
        {
            _logger.LogWarning(
                "Attempted to delete category {CategoryId} that still has books assigned to it", id);

            throw new ConflictException(
                $"Cannot delete category {id}: it has books assigned to it. " +
                "Reassign or remove those books before deleting this category.");
        }

        _unitOfWork.Categories.Delete(category);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Deleted category: {CategoryId}", id);
        return true;
    }
}