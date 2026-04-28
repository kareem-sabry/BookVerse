namespace BookVerse.Core.Interfaces;

public interface ITimestampedEntity
{
    DateTime CreatedAtUtc { get; set; }
}