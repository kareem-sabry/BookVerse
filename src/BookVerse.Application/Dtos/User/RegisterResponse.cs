namespace BookVerse.Application.Dtos.User;

public record RegisterResponse : BasicResponse
{
    public IEnumerable<string> Errors { get; init; } = Array.Empty<string>();
}