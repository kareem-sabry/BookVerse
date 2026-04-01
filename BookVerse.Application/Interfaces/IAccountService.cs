using BookVerse.Application.Dtos.User;
using Microsoft.AspNetCore.Identity.Data;
using LoginRequest = BookVerse.Application.Dtos.User.LoginRequest;
using RegisterRequest = BookVerse.Application.Dtos.User.RegisterRequest;

namespace BookVerse.Application.Interfaces;

public interface IAccountService
{
    Task<RegisterResponse> RegisterAsync(RegisterRequest registerRequest);
    Task<LoginResponse> LoginAsync(LoginRequest request);

    Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest refreshTokenRequest,
        CancellationToken cancellationToken = default);

    Task<LogoutResponse> LogoutAsync(string userEmail);
    Task<UserProfileDto?> GetCurrentUserAsync(string userEmail);
    Task<BasicResponse> ForgotPasswordAsync(ForgotPasswordRequest request);
    Task<BasicResponse> ResetPasswordAsync(ResetPasswordRequest request);
    Task<BasicResponse> DeleteMyAccountAsync(string userEmail);
}