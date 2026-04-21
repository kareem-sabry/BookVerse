using BookVerse.Application.Dtos.User;
using BookVerse.Application.Interfaces;
using BookVerse.Core.Constants;
using BookVerse.Core.Entities;
using BookVerse.Core.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using LoginRequest = BookVerse.Application.Dtos.User.LoginRequest;
using RegisterRequest = BookVerse.Application.Dtos.User.RegisterRequest;

namespace BookVerse.Infrastructure.Services;

public class AccountService : IAccountService
{
    private readonly IAuthTokenProcessor _authTokenProcessor;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEmailService _emailService;
    private readonly ILogger<AccountService> _logger;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;
    private readonly UserManager<User> _userManager;

    public AccountService(IAuthTokenProcessor authTokenProcessor, UserManager<User> userManager,
        RoleManager<IdentityRole<Guid>> roleManager, IEmailService emailService,
        ILogger<AccountService> logger, IDateTimeProvider dateTimeProvider, IUnitOfWork unitOfWork)
    {
        _authTokenProcessor = authTokenProcessor;
        _userManager = userManager;
        _roleManager = roleManager;
        _emailService = emailService;
        _logger = logger;
        _dateTimeProvider = dateTimeProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task<RegisterResponse> RegisterAsync(RegisterRequest registerRequest,
        CancellationToken cancellationToken = default)
    {
        var userExists = await _userManager.FindByEmailAsync(registerRequest.Email) != null;

        if (userExists)
        {
            _logger.LogWarning("Registration attempt with existing email: {Email}", registerRequest.Email);

            return new RegisterResponse
            {
                Succeeded = false,
                Message = ErrorMessages.UserAlreadyExists,
                Errors = new[] { ErrorMessages.UserAlreadyExists }
            };
        }

        if (registerRequest.Role != Role.User)
        {
            _logger.LogWarning("Attempt to register with invalid role: {Role}", registerRequest.Role);
            return new RegisterResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidRole,
                Errors = new[] { ErrorMessages.CannotRegisterAsAdmin }
            };
        }

        var identityRoleName = GetIdentityRoleName(registerRequest.Role);

        var roleExists = await _roleManager.RoleExistsAsync(identityRoleName);

        if (!roleExists)
        {
            _logger.LogError("Invalid role specified during registration: {Role}", registerRequest.Role);

            return new RegisterResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidRole,
                Errors = new[] { ErrorMessages.RoleDoesNotExist }
            };
        }


        var user = User.Create(registerRequest.Email, registerRequest.FirstName, registerRequest.LastName);
        user.CreatedAtUtc = _dateTimeProvider.UtcNow;

        var result = await _userManager.CreateAsync(user, registerRequest.Password);

        if (!result.Succeeded)
        {
            _logger.LogWarning("User registration failed for {Email}: {Errors}",
                registerRequest.Email,
                string.Join(", ", result.Errors.Select(e => e.Description)));

            return new RegisterResponse
            {
                Succeeded = false,
                Message = ErrorMessages.RegistrationFailed,
                Errors = result.Errors.Select(x => x.Description)
            };
        }

        await _userManager.AddToRoleAsync(user, identityRoleName);

        _logger.LogInformation("User registered successfully: {Email} with role {Role}",
            user.Email, identityRoleName);

        return new RegisterResponse
        {
            Succeeded = true,
            Message = SuccessMessages.RegistrationSuccessful
        };
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest,
        CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByEmailAsync(loginRequest.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, loginRequest.Password))
        {
            _logger.LogWarning("Failed login attempt for email: {Email}", loginRequest.Email);

            return new LoginResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidCredentials
            };
        }


        var roles = await _userManager.GetRolesAsync(user);
        var (jwtToken, expirationDateInUtc) = _authTokenProcessor.GenerateJwtToken(user, roles);

        var refreshTokenValue = _authTokenProcessor.GenerateRefreshToken();

        var refreshTokenExpirationDateInUtc =
            _dateTimeProvider.UtcNow.AddDays(ApplicationConstants.RefreshTokenExpirationDays);

        user.PreviousRefreshToken = null;
        user.RefreshToken = HashToken(refreshTokenValue);
        user.RefreshTokenExpiresAtUtc = refreshTokenExpirationDateInUtc;

        await _userManager.UpdateAsync(user);
        _logger.LogInformation("User logged in successfully: {Email}", user.Email);

        return new LoginResponse
        {
            Succeeded = true,
            Message = SuccessMessages.LoginSuccessful,
            AccessToken = jwtToken,
            ExpiresAtUtc = expirationDateInUtc,
            RefreshToken = refreshTokenValue
        };
    }

    public async Task<BasicResponse> DeleteMyAccountAsync(string userEmail,
        CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByEmailAsync(userEmail);

        if (user == null)
        {
            _logger.LogWarning("Account deletion attempted for non-existent user: {Email}", userEmail);

            return new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.UserNotFound
            };
        }

        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded)
        {
            _logger.LogError("Failed to delete account for {Email}: {Errors}",
                userEmail,
                string.Join(", ", result.Errors.Select(e => e.Description)));

            return new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.OperationFailed
            };
        }

        _logger.LogInformation("Account deleted successfully: {Email}", userEmail);

        return new BasicResponse
        {
            Succeeded = true,
            Message = SuccessMessages.AccountDeleted
        };
    }

    public async Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest refreshTokenRequest,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(refreshTokenRequest.RefreshToken))
            return new RefreshTokenResponse
            {
                Succeeded = false,
                Message = ErrorMessages.RefreshTokenMissing
            };

        var hashedIncoming = HashToken(refreshTokenRequest.RefreshToken);

        var user = await _unitOfWork.Users.GetUserByRefreshTokenAsync(hashedIncoming, cancellationToken);

        if (user == null)
        {
            // Check if this is a previously-rotated (consumed) token — indicates possible theft.

            var previousTokenUser =
                await _unitOfWork.Users.GetUserByPreviousRefreshTokenAsync(hashedIncoming, cancellationToken);

            if (previousTokenUser != null)
            {
                _logger.LogWarning(
                    "Consumed refresh token reuse detected for user {UserId} — revoking all tokens (possible theft)",
                    previousTokenUser.Id);
                previousTokenUser.RefreshToken = null;
                previousTokenUser.PreviousRefreshToken = null;
                previousTokenUser.RefreshTokenExpiresAtUtc = null;

                await _userManager.UpdateAsync(previousTokenUser);
            }
            else
            {
                _logger.LogWarning("Invalid refresh token attempt");
            }

            return new RefreshTokenResponse
            {
                Succeeded = false,
                Message = ErrorMessages.RefreshTokenInvalid
            };
        }

        if (user.RefreshTokenExpiresAtUtc < _dateTimeProvider.UtcNow)
        {
            _logger.LogInformation("Expired refresh token used for user: {Email}", user.Email);

            return new RefreshTokenResponse
            {
                Succeeded = false,
                Message = ErrorMessages.RefreshTokenExpired
            };
        }

        var roles = await _userManager.GetRolesAsync(user);
        var (jwtToken, expirationDateInUtc) = _authTokenProcessor.GenerateJwtToken(user, roles);

        var refreshTokenValue = _authTokenProcessor.GenerateRefreshToken();
        var refreshTokenExpirationDateInUtc =
            _dateTimeProvider.UtcNow.AddDays(ApplicationConstants.RefreshTokenExpirationDays);

        user.PreviousRefreshToken = user.RefreshToken;
        user.RefreshToken = HashToken(refreshTokenValue);
        user.RefreshTokenExpiresAtUtc = refreshTokenExpirationDateInUtc;

        await _userManager.UpdateAsync(user);

        _logger.LogInformation("Token refreshed for user: {Email}", user.Email);

        return new RefreshTokenResponse
        {
            Succeeded = true,
            Message = SuccessMessages.TokenRefreshed,
            AccessToken = jwtToken,
            ExpiresAtUtc = expirationDateInUtc,
            RefreshToken = refreshTokenValue
        };
    }

    public async Task<BasicResponse> ForgotPasswordAsync(ForgotPasswordRequest request,
        CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
        {
            _logger.LogInformation("Password reset requested for non-existent email: {Email}", request.Email);

            return new BasicResponse
            {
                Succeeded = true,
                Message = SuccessMessages.PasswordResetEmailSent
            };
        }

        var rawToken = await _userManager.GeneratePasswordResetTokenAsync(user);
        // URL-encode the token: raw Identity tokens contain +, /, = which break URLs.
        // In production, a full reset URL should be sent instead of a raw token:
        // https://bookverseapi.com/reset-password?token={encodedToken}&email={user.Email}
        var token = Uri.EscapeDataString(rawToken);

        var emailBody = $"""
                         Hello {user.FirstName},

                         You requested to reset your password for BookVerse.Api.

                         Please use the following token to reset your password:

                         {token}

                         This token will expire in {ApplicationConstants.PasswordResetTokenExpirationHours} hours.

                         If you didn't request this password reset, please ignore this email and your password will remain unchanged.

                         For security reasons, never share this token with anyone.

                         Best regards,
                         BookVerse.Api Support Team
                         """;

        await _emailService.SendEmailAsync(
            user.Email!,
            "BookVerse.Api Password Reset",
            emailBody, cancellationToken);
        _logger.LogInformation("Password reset email sent to: {Email}", user.Email);

        return new BasicResponse
        {
            Succeeded = true,
            Message = SuccessMessages.PasswordResetEmailSent
        };
    }

    public async Task<BasicResponse> ResetPasswordAsync(ResetPasswordRequest request,
        CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
        {
            _logger.LogWarning("Password reset attempted for non-existent email: {Email}", request.Email);

            return new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidPasswordResetRequest
            };
        }

        var decodedToken = Uri.UnescapeDataString(request.ResetCode);
        var result = await _userManager.ResetPasswordAsync(user, decodedToken,
            request.NewPassword);

        if (!result.Succeeded)
        {
            _logger.LogWarning("Password reset failed for {Email}: {Errors}",
                request.Email,
                string.Join(", ", result.Errors.Select(e => e.Description)));
            return new BasicResponse
            {
                Succeeded = false,
                Message = string.Join(", ", result.Errors.Select(e => e.Description))
            };
        }

        user.RefreshToken = null;
        user.RefreshTokenExpiresAtUtc = null;
        await _userManager.UpdateAsync(user);

        _logger.LogInformation("Password reset successfully for: {Email}", user.Email);

        return new BasicResponse
        {
            Succeeded = true,
            Message = SuccessMessages.PasswordResetSuccessful
        };
    }

    public async Task<LogoutResponse> LogoutAsync(string userEmail, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByEmailAsync(userEmail);
        if (user == null)
        {
            _logger.LogWarning("Logout attempted for non-existent user: {Email}", userEmail);

            return new LogoutResponse
            {
                Succeeded = false,
                Message = ErrorMessages.UserNotFound
            };
        }

        // Invalidate the refresh token
        user.RefreshToken = null;
        user.RefreshTokenExpiresAtUtc = null;
        await _userManager.UpdateAsync(user);

        _logger.LogInformation("User logged out: {Email}", userEmail);

        return new LogoutResponse
        {
            Succeeded = true,
            Message = SuccessMessages.LogoutSuccessful
        };
    }

    public async Task<UserProfileDto?> GetCurrentUserAsync(string userEmail,
        CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByEmailAsync(userEmail);
        if (user == null)
        {
            _logger.LogWarning("User profile requested for non-existent user: {Email}", userEmail);

            return null;
        }

        return new UserProfileDto
        {
            Email = user.Email ?? string.Empty,
            FirstName = user.FirstName,
            LastName = user.LastName,
            CreatedAtUtc = user.CreatedAtUtc,
            UpdatedAtUtc = user.UpdatedAtUtc
        };
    }

    private string GetIdentityRoleName(Role role)
    {
        return role switch
        {
            Role.User => IdentityRoleConstants.User,
            Role.Admin => IdentityRoleConstants.Admin,
            _ => throw new ArgumentOutOfRangeException(nameof(role), role, "Provided role is not supported.")
        };
    }

    private static string HashToken(string token)
    {
        var bytes = System.Security.Cryptography.SHA256.HashData(
            System.Text.Encoding.UTF8.GetBytes(token));
        return Convert.ToBase64String(bytes);
    }
}