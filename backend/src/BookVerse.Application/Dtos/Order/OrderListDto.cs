using BookVerse.Core.Enums;

namespace BookVerse.Application.Dtos.Order;

public class OrderListDto
{
    public int Id { get; set; }
    public string OrderNumber { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; }
    public OrderStatus Status { get; set; }
    public string StatusDisplay => Status.ToString();
    public decimal TotalAmount { get; set; }
    public int ItemCount { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public string PaymentStatusDisplay => PaymentStatus.ToString();
    public DateTime CreatedAtUtc { get; set; }
}