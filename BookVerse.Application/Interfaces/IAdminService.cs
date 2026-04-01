using BookVerse.Application.Dtos.User;

namespace BookVerse.Application.Interfaces;

public interface IAdminService
{
    Task<IEnumerable<UserWithRolesDto>> GetAllUsersAsync(CancellationToken cancellationToken);
    Task<UserWithRolesDto?> GetUserByIdAsync(Guid userId);
    Task<BasicResponse> MakeUserAdminAsync(Guid userId, string currentAdminEmail);
    Task<BasicResponse> RemoveAdminRoleAsync(Guid userId, Guid currentAdminId);
    Task<BasicResponse> DeleteUserAsync(Guid userId, string currentAdminEmail);
}