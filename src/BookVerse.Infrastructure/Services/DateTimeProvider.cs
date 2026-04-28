using BookVerse.Application.Interfaces;

namespace BookVerse.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}