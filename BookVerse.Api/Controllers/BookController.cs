using Asp.Versioning;
using BookVerse.Application.Dtos.Book;
using BookVerse.Application.Dtos.User;
using BookVerse.Application.Interfaces;
using BookVerse.Core.Constants;
using BookVerse.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace BookVerse.Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[EnableRateLimiting("api")]
[Produces("application/json")]
public class BookController : ControllerBase
{
    private readonly IBooksService _booksService;

    public BookController(IBooksService booksService)
    {
        _booksService = booksService;
    }

    [HttpGet]
    [AllowAnonymous]
    [ResponseCache(Duration = 300, Location = ResponseCacheLocation.Any,
        VaryByQueryKeys = new[] { "*" })]
    [ProducesResponseType(typeof(PagedResult<BookReadDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBooks([FromQuery] BookQueryParameters parameters,
        CancellationToken cancellationToken = default)
    {
        var books = await _booksService.GetPagedAsync(parameters, cancellationToken);
        return Ok(books);
    }

    [HttpGet("{id:int}")]
    [AllowAnonymous]
    [ResponseCache(Duration = 300, VaryByQueryKeys = new[] { "id" })]
    [ProducesResponseType(typeof(BookReadDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BookReadDto>> GetBookById(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return BadRequest(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidId
            });

        var book = await _booksService.GetByIdAsync(id, cancellationToken);

        if (book == null)
            return NotFound(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.BookNotFound
            });
        return Ok(book);
    }

    [HttpPost]
    [Authorize(Roles = IdentityRoleConstants.Admin)]
    [ProducesResponseType(typeof(BookReadDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<BookReadDto>> CreateBook([FromBody] BookCreateDto bookDto,
        CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
        {
            var errorMessage = string.Join("; ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));

            return BadRequest(new BasicResponse
            {
                Succeeded = false,
                Message = errorMessage
            });
        }

        var createdBook = await _booksService.CreateAsync(bookDto, cancellationToken);
        return CreatedAtAction(nameof(GetBookById), new { id = createdBook.Id }, createdBook);
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = IdentityRoleConstants.Admin)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] BookUpdateDto bookDto,
        CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return BadRequest(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidId
            });

        if (!ModelState.IsValid)
        {
            var errorMessage = string.Join("; ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));

            return BadRequest(new BasicResponse
            {
                Succeeded = false,
                Message = errorMessage
            });
        }

        var updated = await _booksService.UpdateAsync(id, bookDto, cancellationToken);

        if (!updated)
            return NotFound(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.BookNotFound
            });

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = IdentityRoleConstants.Admin)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteBook(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            return BadRequest(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidId
            });
        var deleted = await _booksService.DeleteAsync(id, cancellationToken);

        if (!deleted)
            return NotFound(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.BookNotFound
            });

        return NoContent();
    }
}