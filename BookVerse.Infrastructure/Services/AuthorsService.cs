using AutoMapper;
using BookVerse.Application.Dtos.Author;
using BookVerse.Application.Interfaces;
using BookVerse.Core.Entities;
using BookVerse.Core.Models;
using Microsoft.Extensions.Logging;

namespace BookVerse.Infrastructure.Services;

public class AuthorsService : IAuthorsService
{
    private readonly ILogger<AuthorsService> _logger;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AuthorsService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<AuthorsService> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<PagedResult<AuthorListDto>> GetPagedAsync(QueryParameters parameters)
    {
        var pagedAuthors = await _unitOfWork.Authors.GetPagedAsync(parameters);
        var authorDtos = _mapper.Map<IEnumerable<AuthorListDto>>(pagedAuthors.Items);

        return new PagedResult<AuthorListDto>(
            authorDtos,
            pagedAuthors.TotalCount,
            pagedAuthors.CurrentPage,
            pagedAuthors.PageSize
        );
    }

    public async Task<AuthorReadDto?> GetByIdAsync(int id)
    {
        var author = await _unitOfWork.Authors.GetByIdAsync(id);
        if (author == null)
        {
            _logger.LogWarning("Author not found with ID: {AuthorId}", id);
            return null;
        }

        var dto = _mapper.Map<AuthorReadDto>(author);
        _logger.LogInformation("Retrieved author: {AuthorId}", id);
        return dto;
    }

    public async Task<AuthorReadDto> CreateAsync(AuthorCreateDto authorDto)
    {
        var author = _mapper.Map<Author>(authorDto);
        var existingAuthor = await _unitOfWork.Authors.GetByNameAsync(author.FirstName, author.LastName);

        if (existingAuthor != null)
        {
            _logger.LogInformation("Author already exists: {FirstName} {LastName}",
                author.FirstName, author.LastName);
            return _mapper.Map<AuthorReadDto>(existingAuthor);
        }

        await _unitOfWork.Authors.AddAsync(author);
        await _unitOfWork.SaveChangesAsync();

        _logger.LogInformation("Created new author: {FirstName} {LastName}",
            author.FirstName, author.LastName);

        return _mapper.Map<AuthorReadDto>(author);
    }

    public async Task<bool> UpdateAsync(int id, AuthorUpdateDto authorDto)
    {
        var retrievedAuthor = await _unitOfWork.Authors.GetByIdAsync(id);
        if (retrievedAuthor == null)
        {
            _logger.LogWarning("Attempted to update non-existent author with ID: {AuthorId}", id);
            return false;
        }

        _mapper.Map(authorDto, retrievedAuthor);
        _unitOfWork.Authors.Update(retrievedAuthor);
        await _unitOfWork.SaveChangesAsync();

        _logger.LogInformation("Updated author: {AuthorId}", id);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var retrievedAuthor = await _unitOfWork.Authors.GetByIdAsync(id);
        if (retrievedAuthor == null)
        {
            _logger.LogWarning("Attempted to delete non-existent author with ID: {AuthorId}", id);
            return false;
        }

        _unitOfWork.Authors.Delete(retrievedAuthor);
        await _unitOfWork.SaveChangesAsync();

        _logger.LogInformation("Deleted author: {AuthorId}", id);
        return true;
    }

    public async Task<IEnumerable<AuthorListDto>> GetAllAsync()
    {
        var authors = await _unitOfWork.Authors.GetAllAsync();
        var dtos = _mapper.Map<IEnumerable<AuthorListDto>>(authors);

        _logger.LogInformation("Retrieved {Count} authors", dtos.Count());

        return dtos;
    }
}