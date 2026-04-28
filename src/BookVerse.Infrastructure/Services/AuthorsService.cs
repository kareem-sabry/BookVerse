using AutoMapper;
using BookVerse.Application.Dtos.Author;
using BookVerse.Application.Interfaces;
using BookVerse.Core.Constants;
using BookVerse.Core.Entities;
using BookVerse.Core.Exceptions;
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

    public async Task<PagedResult<AuthorListDto>> GetPagedAsync(QueryParameters parameters,
        CancellationToken cancellationToken)
    {
        var pagedAuthors = await _unitOfWork.Authors.GetPagedAsync(parameters, cancellationToken);
        var authorDtos = _mapper.Map<IEnumerable<AuthorListDto>>(pagedAuthors.Items);

        return new PagedResult<AuthorListDto>(
            authorDtos,
            pagedAuthors.TotalCount,
            pagedAuthors.CurrentPage,
            pagedAuthors.PageSize
        );
    }

    public async Task<AuthorReadDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var author = await _unitOfWork.Authors.GetByIdAsync(id, cancellationToken);
        if (author == null)
        {
            _logger.LogWarning("Author not found with ID: {AuthorId}", id);
            return null;
        }

        var dto = _mapper.Map<AuthorReadDto>(author);
        _logger.LogInformation("Retrieved author: {AuthorId}", id);
        return dto;
    }

    public async Task<AuthorReadDto> CreateAsync(AuthorCreateDto authorDto, CancellationToken cancellationToken)
    {
        var author = _mapper.Map<Author>(authorDto);
        var existingAuthor =
            await _unitOfWork.Authors.GetByNameAsync(author.FirstName, author.LastName, cancellationToken);

        if (existingAuthor != null)
        {
            _logger.LogWarning("Duplicate author creation attempted: {FirstName} {LastName}",
                author.FirstName, author.LastName);
            throw new ConflictException(ErrorMessages.AuthorAlreadyExists);
        }

        await _unitOfWork.Authors.AddAsync(author, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Created new author: {FirstName} {LastName}",
            author.FirstName, author.LastName);

        return _mapper.Map<AuthorReadDto>(author);
    }

    public async Task<bool> UpdateAsync(int id, AuthorUpdateDto authorDto, CancellationToken cancellationToken)
    {
        var retrievedAuthor = await _unitOfWork.Authors.GetByIdAsync(id, cancellationToken);
        if (retrievedAuthor == null)
        {
            _logger.LogWarning("Attempted to update non-existent author with ID: {AuthorId}", id);
            return false;
        }

        _mapper.Map(authorDto, retrievedAuthor);
        _unitOfWork.Authors.Update(retrievedAuthor);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Updated author: {AuthorId}", id);
        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var retrievedAuthor = await _unitOfWork.Authors.GetByIdAsync(id, cancellationToken);
        if (retrievedAuthor == null)
        {
            _logger.LogWarning("Attempted to delete non-existent author with ID: {AuthorId}", id);
            return false;
        }

        _unitOfWork.Authors.Delete(retrievedAuthor);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Deleted author: {AuthorId}", id);
        return true;
    }
}