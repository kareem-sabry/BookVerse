using System.ComponentModel.DataAnnotations;
using BookVerse.Core.Interfaces;

namespace BookVerse.Core.Entities;

public class Cart : IAuditable, IEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }

    [MaxLength(100)] public string? CreatedBy { get; set; }

    [MaxLength(100)] public string? UpdatedBy { get; set; }
    [Key] public int Id { get; set; }
}