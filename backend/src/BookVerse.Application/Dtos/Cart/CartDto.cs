namespace BookVerse.Application.Dtos.Cart;

public class CartDto
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public List<CartItemDto> CartItems { get; set; } = new();
    public decimal TotalAmount => CartItems.Sum(i => i.Subtotal);
    public int TotalItems => CartItems.Sum(i => i.Quantity);
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }
}