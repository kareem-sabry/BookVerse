using BookVerse.Application.Dtos.Cart;
using BookVerse.Application.Dtos.User;

namespace BookVerse.Application.Interfaces;

public interface ICartService
{
    Task<CartDto?> GetCartByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<CartDto> AddToCartAsync(Guid userId, CartItemAdd cartItem, CancellationToken cancellationToken = default);

    Task<CartDto?> UpdateCartItemAsync(Guid userId, int cartItemId, CartItemUpdate cartItemUpdate,
        CancellationToken cancellationToken = default);

    Task<BasicResponse> RemoveCartItemAsync(Guid userId, int cartItemId, CancellationToken cancellationToken = default);
    Task<BasicResponse> ClearCartAsync(Guid userId, CancellationToken cancellationToken = default);
}