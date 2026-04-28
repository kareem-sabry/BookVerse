using BookVerse.Core.Entities;

namespace BookVerse.Application.Interfaces;

public interface IAuthTokenProcessor
{
    public (string jwtToken, DateTime expiresAtUtc) GenerateJwtToken(User user, IList<string> roles);
    public string GenerateRefreshToken();
}