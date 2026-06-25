using BookVerse.Application.Interfaces;
using BookVerse.Core.Entities;
using BookVerse.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookVerse.Infrastructure.Repositories;

public class CartRepository : GenericRepository<Cart>, ICartRepository
{
    public CartRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Cart?> GetUserCartAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _dbSet.AsNoTracking().Include(c => c.CartItems).ThenInclude(ci => ci.Book)
            .FirstOrDefaultAsync(c => c.UserId == userId, cancellationToken: cancellationToken);
    }

    public async Task<Cart?> GetCartWithItemsAsync(int cartId, CancellationToken cancellationToken)
    {
        return await _dbSet.Include(c => c.CartItems).ThenInclude(ci => ci.Book)
            .FirstOrDefaultAsync(c => c.Id == cartId, cancellationToken: cancellationToken);
    }

    public async Task<CartItem?> GetCartItemAsync(int cartId, int bookId, CancellationToken cancellationToken)
    {
        return await _context.CartItems.AsNoTracking().FirstOrDefaultAsync(
            ci => ci.CartId == cartId && ci.BookId == bookId,
            cancellationToken: cancellationToken);
    }

    public async Task AddCartItemAsync(CartItem cartItem, CancellationToken cancellationToken)
    {
        await _context.CartItems.AddAsync(cartItem, cancellationToken);
    }

    public void UpdateCartItem(CartItem cartItem)
    {
        _context.CartItems.Update(cartItem);
    }

    public void DeleteCartItem(CartItem cartItem)
    {
        _context.CartItems.Remove(cartItem);
    }

    public async Task ClearCartAsync(int cartId, CancellationToken cancellationToken)
    {
        var cartItems = await _context.CartItems.Where(ci => ci.CartId == cartId)
            .ToListAsync(cancellationToken: cancellationToken);
        _context.CartItems.RemoveRange(cartItems);
    }
}