using BookVerse.Application.Dtos.User;
using BookVerse.Application.Interfaces;
using BookVerse.Core.Constants;
using BookVerse.Core.Entities;
using BookVerse.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookVerse.Infrastructure.Services;

public class AdminService : IAdminService
{
    private readonly ILogger<AdminService> _logger;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;
    private readonly UserManager<User> _userManager;

    public AdminService(UserManager<User> userManager, ILogger<AdminService> logger,
        RoleManager<IdentityRole<Guid>> roleManager)
    {
        _userManager = userManager;
        _logger = logger;
        _roleManager = roleManager;
    }

    public async Task<PagedResult<UserWithRolesDto>> GetAllUsersAsync(QueryParameters parameters,
        CancellationToken cancellationToken)
    {
        var query = _userManager.Users.AsQueryable();

        if (!string.IsNullOrWhiteSpace(parameters.SearchTerm))
        {
            var term = parameters.SearchTerm.Trim();
            query = query.Where(u =>
                (u.Email != null && u.Email.Contains(term)) ||
                u.FirstName.Contains(term) ||
                u.LastName.Contains(term));
        }

        var totalCount = await query.CountAsync(cancellationToken);

        var users = await query
            .OrderBy(u => u.Email)
            .Skip((parameters.PageNumber - 1) * parameters.PageSize)
            .Take(parameters.PageSize)
            .ToListAsync(cancellationToken);

        // GetRolesAsync issues one query per user; bounded to page size (≤100) so acceptable.
        var result = new List<UserWithRolesDto>();
        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            result.Add(new UserWithRolesDto
            {
                Id = user.Id,
                Email = user.Email ?? string.Empty,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Roles = roles.ToList()
            });
        }

        return new PagedResult<UserWithRolesDto>(result, totalCount, parameters.PageNumber, parameters.PageSize);
    }

    public async Task<UserWithRolesDto?> GetUserByIdAsync(Guid userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user == null)
        {
            _logger.LogWarning("User not found: {UserId}", userId);
            return null;
        }

        var roles = await _userManager.GetRolesAsync(user);

        return new UserWithRolesDto
        {
            Id = user.Id,
            Email = user.Email ?? string.Empty,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Roles = roles.ToList()
        };
    }

    public async Task<BasicResponse> MakeUserAdminAsync(Guid userId, string currentAdminEmail)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user == null)
        {
            _logger.LogWarning("Attempted to make non-existent user admin: {UserId}", userId);
            return new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.UserNotFound
            };
        }

        if (user.Email?.Equals(currentAdminEmail, StringComparison.OrdinalIgnoreCase) == true)
        {
            _logger.LogWarning("Admin {Email} attempted to modify own role", currentAdminEmail);

            return new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.CannotModifyOwnAccount
            };
        }

        if (await _userManager.IsInRoleAsync(user, IdentityRoleConstants.Admin))
        {
            _logger.LogInformation("User {Email} is already an admin", user.Email);

            return new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.UserAlreadyAdmin
            };
        }

        var result = await _userManager.AddToRoleAsync(user, IdentityRoleConstants.Admin);

        if (!result.Succeeded)
        {
            _logger.LogError("Failed to grant admin role to {Email}: {Errors}",
                user.Email,
                string.Join(", ", result.Errors.Select(e => e.Description)));

            return new BasicResponse
            {
                Succeeded = false,
                Message = string.Join(", ", result.Errors.Select(e => e.Description))
            };
        }

        _logger.LogInformation("Admin role granted to user {Email} by {AdminEmail}",
            user.Email, currentAdminEmail);

        return new BasicResponse
        {
            Succeeded = true,
            Message = SuccessMessages.AdminRoleGranted
        };
    }

    public async Task<BasicResponse> RemoveAdminRoleAsync(Guid userId, Guid currentAdminId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user == null)
        {
            _logger.LogWarning("Attempted to remove admin role from non-existent user: {UserId}", userId);

            return new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.UserNotFound
            };
        }

        if (user.Id == currentAdminId)
        {
            _logger.LogWarning("Admin {UserId} attempted to remove own admin role", currentAdminId);

            return new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.CannotModifyOwnAccount
            };
        }

        if (!await _userManager.IsInRoleAsync(user, IdentityRoleConstants.Admin))
        {
            _logger.LogInformation("User {Email} is not an admin", user.Email);

            return new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.UserNotAdmin
            };
        }

        var result = await _userManager.RemoveFromRoleAsync(user, IdentityRoleConstants.Admin);

        if (!result.Succeeded)
        {
            _logger.LogError("Failed to remove admin role from {Email}: {Errors}",
                user.Email,
                string.Join(", ", result.Errors.Select(e => e.Description)));

            return new BasicResponse
            {
                Succeeded = false,
                Message = string.Join(", ", result.Errors.Select(e => e.Description))
            };
        }

        if (!await _userManager.IsInRoleAsync(user, IdentityRoleConstants.User))
        {
            var addResult = await _userManager.AddToRoleAsync(user, IdentityRoleConstants.User);
            if (!addResult.Succeeded)
            {
                _logger.LogError("Failed to add User role to {Email}: {Errors}",
                    user.Email,
                    string.Join(", ", addResult.Errors.Select(e => e.Description)));

                return new BasicResponse
                {
                    Succeeded = false,
                    Message = string.Join(", ", addResult.Errors.Select(e => e.Description))
                };
            }
        }

        _logger.LogInformation("Admin role removed from user {Email}", user.Email);

        return new BasicResponse
        {
            Succeeded = true,
            Message = SuccessMessages.AdminRoleRemoved
        };
    }

    public async Task<BasicResponse> DeleteUserAsync(Guid userId, string currentAdminEmail)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user == null)
        {
            _logger.LogWarning("Attempted to delete non-existent user: {UserId}", userId);
            return new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.UserNotFound
            };
        }

        if (user.Email?.Equals(currentAdminEmail, StringComparison.OrdinalIgnoreCase) == true)
        {
            _logger.LogWarning("Admin {Email} attempted to delete own account", currentAdminEmail);
            return new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.CannotModifyOwnAccount
            };
        }

        var result = await _userManager.DeleteAsync(user);

        if (!result.Succeeded)
        {
            _logger.LogError("Failed to delete user {Email}: {Errors}",
                user.Email,
                string.Join(", ", result.Errors.Select(e => e.Description)));

            return new BasicResponse
            {
                Succeeded = false,
                Message = string.Join(", ", result.Errors.Select(e => e.Description))
            };
        }

        _logger.LogInformation("User {Email} deleted by admin", user.Email);

        return new BasicResponse
        {
            Succeeded = true,
            Message = SuccessMessages.AccountDeleted
        };
    }
}