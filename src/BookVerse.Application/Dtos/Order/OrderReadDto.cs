using BookVerse.Core.Enums;

namespace BookVerse.Application.Dtos.Order;

public class OrderReadDto
{
    public int Id { get; set; }
    public string OrderNumber { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; }
    public OrderStatus Status { get; set; }
    public string StatusDisplay => Status.ToString();
    public decimal TotalAmount { get; set; }
    public string ShippingAddress { get; set; } = string.Empty;
    public string? PaymentMethod { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public string PaymentStatusDisplay => PaymentStatus.ToString();
    public string? Notes { get; set; }
    public List<OrderItemDto> OrderItems { get; set; } = new();
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
}