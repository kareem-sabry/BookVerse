using System.ComponentModel.DataAnnotations;
using BookVerse.Core.Enums;

namespace BookVerse.Application.Dtos.Order;

public class OrderUpdateStatusDto
{
    [Required(ErrorMessage = "Order status is required")]
    [EnumDataType(typeof(OrderStatus), ErrorMessage = "Invalid order status")]
    public OrderStatus Status { get; set; }

    [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters")]
    public string? Notes { get; set; }
}