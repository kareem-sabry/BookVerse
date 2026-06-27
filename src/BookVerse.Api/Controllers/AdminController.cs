using Asp.Versioning;
using BookVerse.Api.Extensions;
using BookVerse.Application.Dtos.User;
using BookVerse.Application.Interfaces;
using BookVerse.Core.Constants;
using BookVerse.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookVerse.Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[Authorize(Roles = IdentityRoleConstants.Admin)]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpGet("users")]
    [ProducesResponseType(typeof(PagedResult<UserWithRolesDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetAllUsers([FromQuery] QueryParameters parameters,
        CancellationToken cancellationToken = default)
    {
        var users = await _adminService.GetAllUsersAsync(parameters, cancellationToken);
        return Ok(users);
    }

    [HttpGet("users/{userId:guid}")]
    [ProducesResponseType(typeof(UserWithRolesDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserById(Guid userId, CancellationToken cancellationToken = default)
    {
        var user = await _adminService.GetUserByIdAsync(userId);
        if (user == null)
            return NotFound(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.UserNotFound
            });
        return Ok(user);
    }

    [HttpPost("users/{userId:guid}/make-admin")]
    [ProducesResponseType(typeof(BasicResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BasicResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> MakeUserAdmin(Guid userId, CancellationToken cancellationToken = default)
    {
        var currentAdminEmail = User.GetUserEmail();
        if (currentAdminEmail == null)
            return Unauthorized(new BasicResponse { Succeeded = false, Message = ErrorMessages.InvalidUserContext });

        var response = await _adminService.MakeUserAdminAsync(userId, currentAdminEmail);
        if (!response.Succeeded)
            return BadRequest(response);
        return Ok(response);
    }

    [HttpPost("users/{userId:guid}/remove-admin")]
    [ProducesResponseType(typeof(BasicResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BasicResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveAdminRole(Guid userId, CancellationToken cancellationToken = default)
    {
        var currentAdminId = User.GetUserId();
        if (currentAdminId == null)
            return Unauthorized(new BasicResponse { Succeeded = false, Message = ErrorMessages.InvalidUserContext });

        var response = await _adminService.RemoveAdminRoleAsync(userId, currentAdminId.Value);
        if (!response.Succeeded)
            return BadRequest(response);
        return Ok(response);
    }

    [HttpDelete("users/{userId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(BasicResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteUser(Guid userId, CancellationToken cancellationToken = default)
    {
        var currentAdminEmail = User.GetUserEmail();
        if (currentAdminEmail == null)
            return Unauthorized(new BasicResponse { Succeeded = false, Message = ErrorMessages.InvalidUserContext });

        var response = await _adminService.DeleteUserAsync(userId, currentAdminEmail);
        if (!response.Succeeded)
            return BadRequest(response);
        return NoContent();
    }
}