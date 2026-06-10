using System.ComponentModel.DataAnnotations;
using BookVerse.Core.Enums;

namespace BookVerse.Application.Dtos.Order;

public class PaymentUpdateStatusDto
{
    [Required(ErrorMessage = "Payment status is required")]
    [EnumDataType(typeof(PaymentStatus), ErrorMessage = "Invalid payment status")]
    public PaymentStatus PaymentStatus { get; set; }
}