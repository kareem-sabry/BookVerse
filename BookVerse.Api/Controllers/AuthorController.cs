using Asp.Versioning;
using BookVerse.Application.Dtos.Author;
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
public class AuthorController : ControllerBase
{
    private readonly IAuthorsService _service;

    public AuthorController(IAuthorsService service)
    {
        _service = service;
    }

    [HttpGet]
    [AllowAnonymous]
    [ResponseCache(Duration = 300, Location = ResponseCacheLocation.Any)]
    [ProducesResponseType(typeof(PagedResult<AuthorListDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAuthors([FromQuery] QueryParameters parameters)
    {
        var authors = await _service.GetPagedAsync(parameters);
        return Ok(authors);
    }

    [HttpGet("{id:int}")]
    [AllowAnonymous]
    [ResponseCache(Duration = 300, VaryByQueryKeys = new[] { "id" })]
    [ProducesResponseType(typeof(AuthorReadDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AuthorReadDto>> GetAuthor(int id)
    {
        if (id <= 0)
            return BadRequest(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidId
            });
        var author = await _service.GetByIdAsync(id);
        if (author == null)
            return NotFound(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.AuthorNotFound
            });
        return Ok(author);
    }

    [HttpPost]
    [Authorize(Roles = IdentityRoleConstants.Admin)]
    [ProducesResponseType(typeof(AuthorReadDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<AuthorReadDto>> CreateAuthor([FromBody] AuthorCreateDto authorDto)
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

        var createdAuthor = await _service.CreateAsync(authorDto);

        return CreatedAtAction(nameof(GetAuthor), new { id = createdAuthor.Id }, createdAuthor);
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = IdentityRoleConstants.Admin)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAuthor(int id, [FromBody] AuthorUpdateDto authorDto)
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

        var updated = await _service.UpdateAsync(id, authorDto);

        if (!updated)
            return NotFound(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.AuthorNotFound
            });

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = IdentityRoleConstants.Admin)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAuthor(int id)
    {
        if (id <= 0)
            return BadRequest(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidId
            });

        var deleted = await _service.DeleteAsync(id);
        if (!deleted)
            return NotFound(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.AuthorNotFound
            });

        return NoContent();
    }
}