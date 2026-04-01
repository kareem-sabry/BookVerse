using System.Security.Claims;
using Asp.Versioning;
using BookVerse.Application.Dtos.User;
using BookVerse.Application.Interfaces;
using BookVerse.Core.Constants;
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
    [ProducesResponseType(typeof(IEnumerable<UserWithRolesDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _adminService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("users/{userId:guid}")]
    [ProducesResponseType(typeof(UserWithRolesDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserById(Guid userId)
    {
        if (userId == Guid.Empty)
            return BadRequest(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidId
            });

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
    public async Task<IActionResult> MakeUserAdmin(Guid userId)
    {
        if (userId == Guid.Empty)
            return BadRequest(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidId
            });

        var currentAdminEmail = User.FindFirstValue(ClaimTypes.Email);
        if (string.IsNullOrWhiteSpace(currentAdminEmail))
            return Unauthorized(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidUserContext
            });

        var response = await _adminService.MakeUserAdminAsync(userId, currentAdminEmail);

        if (response.Succeeded)
            return Ok(response);

        return BadRequest(response);
    }

    [HttpPost("users/{userId:guid}/remove-admin")]
    [ProducesResponseType(typeof(BasicResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BasicResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveAdminRole(Guid userId)
    {
        if (userId == Guid.Empty)
            return BadRequest(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidId
            });
        var currentAdminIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;


        if (string.IsNullOrWhiteSpace(currentAdminIdClaim) ||
            !Guid.TryParse(currentAdminIdClaim, out var currentAdminId))
            return Unauthorized(new BasicResponse { Succeeded = false, Message = ErrorMessages.InvalidUserContext });

        var response = await _adminService.RemoveAdminRoleAsync(userId, currentAdminId);

        if (response.Succeeded)
            return Ok(response);

        return BadRequest(response);
    }

    [HttpDelete("users/{userId:guid}")]
    [ProducesResponseType(typeof(BasicResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BasicResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteUser(Guid userId)
    {
        if (userId == Guid.Empty)
            return BadRequest(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidId
            });

        var currentAdminEmail = User.FindFirstValue(ClaimTypes.Email);
        if (string.IsNullOrWhiteSpace(currentAdminEmail))
            return Unauthorized(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidUserContext
            });

        var response = await _adminService.DeleteUserAsync(userId, currentAdminEmail);

        if (response.Succeeded)
            return Ok(response);

        return BadRequest(response);
    }
}