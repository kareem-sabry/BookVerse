using BookVerse.Core.Entities;

namespace BookVerse.Application.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserByRefreshTokenAsync(string refreshToken, CancellationToken cancellationToken = default);
    Task<User?> GetUserByPreviousRefreshTokenAsync(string previousRefreshTokenHash, CancellationToken cancellationToken);

}