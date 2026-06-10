namespace BookVerse.Application.Interfaces;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}