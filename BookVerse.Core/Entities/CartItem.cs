using System.ComponentModel.DataAnnotations;
using BookVerse.Core.Interfaces;

namespace BookVerse.Core.Entities;

public class CartItem : IAuditable, IEntity
{
    public int CartId { get; set; }
    public Cart Cart { get; set; } = null!;


    public int BookId { get; set; }
    public Book Book { get; set; } = null!;

    [Range(1, 100)] public int Quantity { get; set; }

    public decimal PriceAtAdd { get; set; }

    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }

    [MaxLength(100)] public string? CreatedBy { get; set; }

    [MaxLength(100)] public string? UpdatedBy { get; set; }
    [Key] public int Id { get; set; }
}