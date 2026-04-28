using System.ComponentModel.DataAnnotations;

namespace BookVerse.Application.Dtos.Cart;

public class CartItemUpdate
{
    [Required(ErrorMessage = "Quantity is required")]
    [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100")]
    public int Quantity { get; set; }
}