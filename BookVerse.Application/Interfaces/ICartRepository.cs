using BookVerse.Core.Entities;

namespace BookVerse.Application.Interfaces;

public interface ICartRepository : IGenericRepository<Cart>
{
    Task<Cart?> GetUserCartAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<Cart?> GetCartWithItemsAsync(int cartId, CancellationToken cancellationToken = default);
    Task<CartItem?> GetCartItemAsync(int cartId, int bookId, CancellationToken cancellationToken = default);
    Task AddCartItemAsync(CartItem cartItem, CancellationToken cancellationToken = default);
    void UpdateCartItem(CartItem cartItem, CancellationToken cancellationToken = default);
    void DeleteCartItem(CartItem cartItem, CancellationToken cancellationToken = default);
    Task ClearCartAsync(int cartId, CancellationToken cancellationToken = default);
}