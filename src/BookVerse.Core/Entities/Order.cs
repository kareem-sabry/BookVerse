using System.ComponentModel.DataAnnotations;
using BookVerse.Core.Enums;
using BookVerse.Core.Interfaces;

namespace BookVerse.Core.Entities;

public class Order : IAuditable, IEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    [Required] [MaxLength(50)] public string OrderNumber { get; set; } = string.Empty;

    public DateTime OrderDate { get; set; }

    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    public decimal TotalAmount { get; set; }

    [Required] [MaxLength(500)] public string ShippingAddress { get; set; } = string.Empty;

    [MaxLength(50)] public string? PaymentMethod { get; set; }

    public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;

    [MaxLength(100)] public string? StripePaymentIntentId { get; set; }

    [MaxLength(1000)] public string? Notes { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }

    [MaxLength(100)] public string? CreatedBy { get; set; }

    [MaxLength(100)] public string? UpdatedBy { get; set; }
    [Key] public int Id { get; set; }

    // Optimistic concurrency token — mirrors the Book entity pattern.
    // EF Core adds WHERE RowVersion = @original to every UPDATE, so concurrent
    // modifications (double-cancel, race on status update) surface as
    // DbUpdateConcurrencyException instead of silently overwriting each other.
    [Timestamp] public byte[] RowVersion { get; set; } = Array.Empty<byte>();
}