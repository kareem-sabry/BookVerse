using System.Security.Claims;
using Asp.Versioning;
using BookVerse.Application.Dtos.User;
using BookVerse.Application.Interfaces;
using BookVerse.Core.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using LoginRequest = BookVerse.Application.Dtos.User.LoginRequest;
using RegisterRequest = BookVerse.Application.Dtos.User.RegisterRequest;
using ResetPasswordRequest = Microsoft.AspNetCore.Identity.Data.ResetPasswordRequest;

namespace BookVerse.Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class AuthController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AuthController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    [EnableRateLimiting("auth")]
    [ProducesResponseType(typeof(RegisterResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(RegisterResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var response = await _accountService.RegisterAsync(registerRequest);

        if (response.Succeeded) return Ok(response);

        return BadRequest(response);
    }

    [HttpPost("login")]
    [AllowAnonymous]
    [EnableRateLimiting("auth")]
    [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
            return BadRequest(new RegisterResponse
            {
                Succeeded = false,
                Errors = errors
            });
        }

        var response = await _accountService.LoginAsync(loginRequest);
        if (response.Succeeded) return Ok(response);

        return BadRequest(response);
    }

    [HttpPost("refresh-token")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(RefreshTokenResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest refreshTokenRequest)
    {
        if (!ModelState.IsValid)
        {
            var errorMessage = string.Join("; ", ModelState.Values.SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));

            return BadRequest(new LoginResponse
            {
                Succeeded = false,
                Message = errorMessage
            });
        }

        var response = await _accountService.RefreshTokenAsync(refreshTokenRequest);
        if (!response.Succeeded) return Unauthorized(response);

        return Ok(response);
    }

    [Authorize]
    [HttpPost("logout")]
    [ProducesResponseType(typeof(LogoutResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(LogoutResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(LogoutResponse), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Logout()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        if (string.IsNullOrWhiteSpace(email))
            return BadRequest(new LogoutResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidUserContext
            });

        var response = await _accountService.LogoutAsync(email);
        if (response.Succeeded) return Ok(response);

        return BadRequest(response);
    }

    [Authorize]
    [HttpGet("me")]
    [ProducesResponseType(typeof(UserProfileDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCurrentUser()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        if (string.IsNullOrWhiteSpace(email))
            return Unauthorized(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidUserContext
            });

        var user = await _accountService.GetCurrentUserAsync(email);
        if (user == null)
            return NotFound(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.UserNotFound
            });
        return Ok(user);
    }

    [AllowAnonymous]
    [HttpPost("forgot-password")]
    [ProducesResponseType(typeof(BasicResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
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

        var response = await _accountService.ForgotPasswordAsync(request);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("reset-password")]
    [ProducesResponseType(typeof(BasicResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BasicResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
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

        var response = await _accountService.ResetPasswordAsync(request);
        if (response.Succeeded) return Ok(response);

        return BadRequest(response);
    }

    [Authorize]
    [HttpDelete("delete-account")]
    [ProducesResponseType(typeof(BasicResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BasicResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> DeleteMyAccount()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        if (string.IsNullOrWhiteSpace(email))
            return BadRequest(new LogoutResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidUserContext
            });

        var result = await _accountService.DeleteMyAccountAsync(email);
        if (result.Succeeded) return Ok(result);

        return BadRequest(result);
    }
}