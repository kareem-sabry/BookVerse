using BookVerse.Application.Interfaces;
using BookVerse.Core.Entities;
using BookVerse.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookVerse.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUserByRefreshTokenAsync(string refreshToken, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken,
            cancellationToken: cancellationToken);
        return user;
    }
}