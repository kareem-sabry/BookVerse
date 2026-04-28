using System.ComponentModel.DataAnnotations;

namespace BookVerse.Application.Dtos.Order;

public class OrderCreateDto
{
    [Required(ErrorMessage = "Shipping address is required")]
    [StringLength(500, MinimumLength = 10, ErrorMessage = "Shipping address must be between 10 and 500 characters")]
    public string ShippingAddress { get; set; } = string.Empty;

    [StringLength(50, ErrorMessage = "Payment method cannot exceed 50 characters")]
    public string? PaymentMethod { get; set; }

    [StringLength(1000, ErrorMessage = "Notes cannot exceed 1000 characters")]
    public string? Notes { get; set; }
}