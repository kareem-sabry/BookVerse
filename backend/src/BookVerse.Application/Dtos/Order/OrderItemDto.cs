namespace BookVerse.Application.Dtos.Order;

public class OrderItemDto
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public string BookTitle { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal PriceAtOrder { get; set; }
    public decimal Subtotal => PriceAtOrder * Quantity;
}