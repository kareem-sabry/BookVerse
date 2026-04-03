using AutoMapper;
using BookVerse.Application.Dtos.Cart;
using BookVerse.Application.Dtos.User;
using BookVerse.Application.Interfaces;
using BookVerse.Core.Constants;
using BookVerse.Core.Entities;
using Microsoft.Extensions.Logging;

namespace BookVerse.Infrastructure.Services;

public class CartService : ICartService
{
    private readonly ILogger<CartService> _logger;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CartService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CartService> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<CartDto?> GetCartByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var cart = await _unitOfWork.Carts.GetUserCartAsync(userId, cancellationToken);

        if (cart == null)
        {
            _logger.LogInformation("No cart found for user: {UserId}", userId);
            return null;
        }

        var cartDto = _mapper.Map<CartDto>(cart);
        _logger.LogInformation("Retrieved cart for user: {UserId} with {ItemCount} items", userId,
            cartDto.CartItems.Count);
        return cartDto;
    }

    public async Task<CartDto> AddToCartAsync(Guid userId, CartItemAdd cartItem, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync();

        var cart = await _unitOfWork.Carts.GetUserCartAsync(userId, cancellationToken);
        if (cart == null)
        {
            cart = new Cart
            {
                UserId = userId
            };
            await _unitOfWork.Carts.AddAsync(cart, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Created new cart for user: {UserId}", userId);
        }

        var book = await _unitOfWork.Books.GetByIdAsync(cartItem.BookId, cancellationToken);
        if (book == null)
        {
            _logger.LogWarning("Book not found: {BookId}", cartItem.BookId);
            await _unitOfWork.RollbackTransactionAsync();
            throw new KeyNotFoundException(ErrorMessages.BookNotFound);
        }

        if (book.QuantityInStock < cartItem.Quantity)
        {
            _logger.LogWarning("Insufficient stock for book: {BookId}. Requested: {Requested}, Available: {Available}",
                cartItem.BookId, cartItem.Quantity, book.QuantityInStock);
            await _unitOfWork.RollbackTransactionAsync();
            throw new InvalidOperationException(ErrorMessages.InsufficientStock);
        }

        var existingCartItem = await _unitOfWork.Carts.GetCartItemAsync(cart.Id, book.Id, cancellationToken);
        if (existingCartItem != null)
        {
            var newQuantity = existingCartItem.Quantity + cartItem.Quantity;
            if (book.QuantityInStock < newQuantity)
            {
                _logger.LogWarning(
                    "Insufficient stock for book: {BookId}. Requested total: {Requested}, Available: {Available}",
                    cartItem.BookId, newQuantity, book.QuantityInStock);
                await _unitOfWork.RollbackTransactionAsync();
                throw new InvalidOperationException(ErrorMessages.InsufficientStock);
            }

            existingCartItem.Quantity = newQuantity;
            existingCartItem.PriceAtAdd = book.Price;
            _unitOfWork.Carts.UpdateCartItem(existingCartItem, cancellationToken);
            _logger.LogInformation("Updated cart item for book: {BookId}, new quantity: {Quantity}",
                cartItem.BookId, newQuantity);
        }
        else
        {
            var newCartItem = new CartItem
            {
                CartId = cart.Id,
                BookId = cartItem.BookId,
                Quantity = cartItem.Quantity,
                PriceAtAdd = book.Price
            };
            await _unitOfWork.Carts.AddCartItemAsync(newCartItem, cancellationToken);
            _logger.LogInformation("Added new cart item for book: {BookId}, quantity: {Quantity}",
                cartItem.BookId, cartItem.Quantity);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _unitOfWork.CommitTransactionAsync();

        var updatedCart = await _unitOfWork.Carts.GetCartWithItemsAsync(cart.Id, cancellationToken);
        return _mapper.Map<CartDto>(updatedCart!);
    }

    public async Task<CartDto?> UpdateCartItemAsync(Guid userId, int cartItemId, CartItemUpdate cartItemUpdate,
        CancellationToken cancellationToken)
    {
        var cart = await _unitOfWork.Carts.GetUserCartAsync(userId, cancellationToken);

        if (cart == null)
        {
            _logger.LogWarning("Cart not found for user: {UserId}", userId);
            return null;
        }

        var cartItem = cart.CartItems.FirstOrDefault(ci => ci.Id == cartItemId);

        if (cartItem == null)
        {
            _logger.LogWarning("Cart item not found: {CartItemId} in user cart: {UserId}", cartItemId, userId);
            return null;
        }

        var book = await _unitOfWork.Books.GetByIdAsync(cartItem.BookId, cancellationToken);

        if (book == null)
        {
            _logger.LogWarning("Book not found: {BookId}", cartItem.BookId);
            throw new KeyNotFoundException(ErrorMessages.BookNotFound);
        }

        if (book.QuantityInStock < cartItemUpdate.Quantity)
        {
            _logger.LogWarning("Insufficient stock for book: {BookId}. Requested: {Requested}, Available: {Available}",
                cartItem.BookId, cartItemUpdate.Quantity, book.QuantityInStock);
            throw new InvalidOperationException(ErrorMessages.InsufficientStock);
        }

        cartItem.Quantity = cartItemUpdate.Quantity;
        cartItem.PriceAtAdd = book.Price;
        _unitOfWork.Carts.UpdateCartItem(cartItem, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("Updated cart item: {CartItemId} to quantity: {Quantity}", cartItemId,
            cartItemUpdate.Quantity);

        var updatedCart = await _unitOfWork.Carts.GetCartWithItemsAsync(cart.Id, cancellationToken);
        return _mapper.Map<CartDto>(updatedCart!);
    }

    public async Task<BasicResponse> RemoveCartItemAsync(Guid userId, int cartItemId,
        CancellationToken cancellationToken)
    {
        var cart = await _unitOfWork.Carts.GetUserCartAsync(userId, cancellationToken);

        if (cart == null)
        {
            _logger.LogWarning("Cart not found for user: {UserId}", userId);

            return new BasicResponse
            {
                Succeeded = false,
                Message = "Cart not found"
            };
        }

        var cartItem = cart.CartItems.FirstOrDefault(ci => ci.Id == cartItemId);
        if (cartItem == null)
        {
            _logger.LogWarning("Cart item not found: {CartItemId} in user cart: {UserId}", cartItemId, userId);
            return new BasicResponse
            {
                Succeeded = false,
                Message = "Cart item not found"
            };
        }

        _unitOfWork.Carts.DeleteCartItem(cartItem, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Removed cart item: {CartItemId} from user cart: {UserId}", cartItemId, userId);

        return new BasicResponse
        {
            Succeeded = true,
            Message = "Item removed from cart successfully"
        };
    }

    public async Task<BasicResponse> ClearCartAsync(Guid userId, CancellationToken cancellationToken)
    {
        var cart = await _unitOfWork.Carts.GetUserCartAsync(userId, cancellationToken);

        if (cart == null)
        {
            _logger.LogWarning("Cart not found for user: {UserId}", userId);
            return new BasicResponse
            {
                Succeeded = false,
                Message = "Cart not found"
            };
        }

        await _unitOfWork.Carts.ClearCartAsync(cart.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("Cleared cart for user: {UserId}", userId);
        return new BasicResponse
        {
            Succeeded = true,
            Message = "Cart cleared successfully"
        };
    }
}