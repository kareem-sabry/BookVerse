using Asp.Versioning;
using BookVerse.Api.Extensions;
using BookVerse.Application.Dtos.Cart;
using BookVerse.Application.Dtos.User;
using BookVerse.Application.Interfaces;
using BookVerse.Core.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookVerse.Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[Authorize]
[Produces("application/json")]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(CartDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCart(CancellationToken cancellationToken = default)
    {
        var userId = User.GetUserId();
        if (userId == null)
            return Unauthorized(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidUserContext
            });

        var cart = await _cartService.GetCartByUserIdAsync(userId.Value, cancellationToken);

        if (cart == null)
            return NotFound(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.CartNotFound
            });

        return Ok(cart);
    }

    [HttpPost("items")]
    [ProducesResponseType(typeof(CartDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BasicResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> AddToCart([FromBody] CartItemAdd cartItemAdd,
        CancellationToken cancellationToken = default)
    {
        var userId = User.GetUserId();
        if (userId == null)
            return Unauthorized(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidUserContext
            });

        var cart = await _cartService.AddToCartAsync(userId.Value, cartItemAdd, cancellationToken);
        return StatusCode(StatusCodes.Status201Created, cart);
    }

    [HttpPut("items/{cartItemId:int}")]
    [ProducesResponseType(typeof(CartDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BasicResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCartItem(int cartItemId, [FromBody] CartItemUpdate cartItemUpdate,
        CancellationToken cancellationToken = default)
    {
        if (cartItemId <= 0)
            return BadRequest(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidId
            });

        var userId = User.GetUserId();
        if (userId == null)
            return Unauthorized(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidUserContext
            });

        var cart = await _cartService.UpdateCartItemAsync(userId.Value, cartItemId, cartItemUpdate, cancellationToken);

        if (cart == null)
            return NotFound(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.CartItemNotFound
            });

        return Ok(cart);
    }

    [HttpDelete("items/{cartItemId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(BasicResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveCartItem(int cartItemId, CancellationToken cancellationToken = default)
    {
        if (cartItemId <= 0)
            return BadRequest(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidId
            });

        var userId = User.GetUserId();
        if (userId == null)
            return Unauthorized(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidUserContext
            });

        var response = await _cartService.RemoveCartItemAsync(userId.Value, cartItemId, cancellationToken);

        if (response.Succeeded) return NoContent();

        return NotFound(response);
    }

    [HttpDelete("clear-cart")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> ClearCart(CancellationToken cancellationToken = default)
    {
        var userId = User.GetUserId();
        if (userId == null)
            return Unauthorized(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidUserContext
            });

        await _cartService.ClearCartAsync(userId.Value, cancellationToken);
        return NoContent();
    }
}