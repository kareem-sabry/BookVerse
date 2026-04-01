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
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly ILogger<CartService> _logger;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CartService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CartService> logger,
        IDateTimeProvider dateTimeProvider)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<CartDto?> GetCartByUserIdAsync(Guid userId)
    {
        var cart = await _unitOfWork.Carts.GetUserCartAsync(userId);

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

    public async Task<CartDto> AddToCartAsync(Guid userId, CartItemAdd cartItem)
    {
        await _unitOfWork.BeginTransactionAsync();

        var cart = await _unitOfWork.Carts.GetUserCartAsync(userId);
        if (cart == null)
        {
            cart = new Cart
            {
                UserId = userId
            };
            await _unitOfWork.Carts.AddAsync(cart);
            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation("Created new cart for user: {UserId}", userId);
        }

        var book = await _unitOfWork.Books.GetByIdAsync(cartItem.BookId);
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

        var existingCartItem = await _unitOfWork.Carts.GetCartItemAsync(cart.Id, book.Id);
        if (existingCartItem != null)
        {
            var newQuantity = existingCartItem.Quantity + cartItem.Quantity;
            if (book.QuantityInStock < newQuantity)
            {
                _logger.LogWarning(
                    "Insufficient stock for book: {BookId}. Requested total: {Requested}, Available: {Available}",
                    cartItem.BookId, newQuantity, book.QuantityInStock);
                throw new InvalidOperationException(ErrorMessages.InsufficientStock);
            }

            existingCartItem.Quantity = newQuantity;
            existingCartItem.PriceAtAdd = book.Price;
            _unitOfWork.Carts.UpdateCartItem(existingCartItem);
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
            await _unitOfWork.Carts.AddCartItemAsync(newCartItem);
            _logger.LogInformation("Added new cart item for book: {BookId}, quantity: {Quantity}",
                cartItem.BookId, cartItem.Quantity);
        }

        await _unitOfWork.SaveChangesAsync();
        await _unitOfWork.CommitTransactionAsync();

        var updatedCart = await _unitOfWork.Carts.GetCartWithItemsAsync(cart.Id);
        return _mapper.Map<CartDto>(updatedCart!);
    }

    public async Task<CartDto?> UpdateCartItemAsync(Guid userId, int cartItemId, CartItemUpdate cartItemUpdate)
    {
        var cart = await _unitOfWork.Carts.GetUserCartAsync(userId);

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

        var book = await _unitOfWork.Books.GetByIdAsync(cartItem.BookId);

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
        _unitOfWork.Carts.UpdateCartItem(cartItem);
        await _unitOfWork.SaveChangesAsync();
        _logger.LogInformation("Updated cart item: {CartItemId} to quantity: {Quantity}", cartItemId,
            cartItemUpdate.Quantity);

        var updatedCart = await _unitOfWork.Carts.GetCartWithItemsAsync(cart.Id);
        return _mapper.Map<CartDto>(updatedCart!);
    }

    public async Task<BasicResponse> RemoveCartItemAsync(Guid userId, int cartItemId)
    {
        var cart = await _unitOfWork.Carts.GetUserCartAsync(userId);

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

        _unitOfWork.Carts.DeleteCartItem(cartItem);
        await _unitOfWork.SaveChangesAsync();

        _logger.LogInformation("Removed cart item: {CartItemId} from user cart: {UserId}", cartItemId, userId);

        return new BasicResponse
        {
            Succeeded = true,
            Message = "Item removed from cart successfully"
        };
    }

    public async Task<BasicResponse> ClearCartAsync(Guid userId)
    {
        var cart = await _unitOfWork.Carts.GetUserCartAsync(userId);

        if (cart == null)
        {
            _logger.LogWarning("Cart not found for user: {UserId}", userId);
            return new BasicResponse
            {
                Succeeded = false,
                Message = "Cart not found"
            };
        }

        await _unitOfWork.Carts.ClearCartAsync(cart.Id);
        await _unitOfWork.SaveChangesAsync();
        _logger.LogInformation("Cleared cart for user: {UserId}", userId);
        return new BasicResponse
        {
            Succeeded = true,
            Message = "Cart cleared successfully"
        };
    }
}