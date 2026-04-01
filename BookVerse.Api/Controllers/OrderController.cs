using System.Security.Claims;
using Asp.Versioning;
using BookVerse.Application.Dtos.Order;
using BookVerse.Application.Dtos.User;
using BookVerse.Application.Interfaces;
using BookVerse.Core.Constants;
using BookVerse.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookVerse.Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[Authorize]
[Produces("application/json")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService, ILogger<OrderController> logger)
    {
        _orderService = orderService;
        _logger = logger;
    }

    /// <summary>
    ///     Create a new order from the user's cart
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(OrderReadDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BasicResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> CreateOrder([FromBody] OrderCreateDto orderCreateDto)
    {
        if (!ModelState.IsValid)
        {
            var errorMessage = string.Join("; ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
            return BadRequest(new BasicResponse
            {
                Succeeded = false,
                Message = errorMessage
            });
        }

        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrWhiteSpace(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId))
            return Unauthorized(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidUserContext
            });


        var order = await _orderService.CreateOrderFromCartAsync(userId, orderCreateDto);
        return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
    }

    /// <summary>
    ///     Get the current user's orders (paginated)
    /// </summary>
    [HttpGet("my-orders")]
    [ProducesResponseType(typeof(PagedResult<OrderListDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetMyOrders([FromQuery] QueryParameters parameters)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrWhiteSpace(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId))
            return Unauthorized(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidUserContext
            });

        var orders = await _orderService.GetUserOrdersAsync(userId, parameters);
        return Ok(orders);
    }

    /// <summary>
    ///     Get all orders (admin only)
    /// </summary>
    [HttpGet]
    [Authorize(Roles = IdentityRoleConstants.Admin)]
    [ProducesResponseType(typeof(PagedResult<OrderListDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetAllOrders([FromQuery] QueryParameters parameters)
    {
        var orders = await _orderService.GetAllOrdersAsync(parameters);
        return Ok(orders);
    }

    /// <summary>
    ///     Get order details by ID
    /// </summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(OrderReadDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOrderById(int id)
    {
        if (id <= 0)
            return BadRequest(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidId
            });

        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrWhiteSpace(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId))
            return Unauthorized(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidUserContext
            });

        // Check if user is admin
        var isAdmin = User.IsInRole(IdentityRoleConstants.Admin);

        var order = await _orderService.GetOrderByIdAsync(userId, id, isAdmin);
        if (order == null)
            return NotFound(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.OrderNotFound
            });

        return Ok(order);
    }

    /// <summary>
    ///     Cancel an order (user can cancel their own pending/processing orders)
    /// </summary>
    [HttpPut("{id:int}/cancel")]
    [ProducesResponseType(typeof(BasicResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BasicResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CancelOrder(int id)
    {
        if (id <= 0)
            return BadRequest(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidId
            });

        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrWhiteSpace(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId))
            return Unauthorized(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidUserContext
            });

        var response = await _orderService.CancelOrderAsync(userId, id);
        if (response.Succeeded) return Ok(response);

        return BadRequest(response);
    }

    /// <summary>
    ///     Update order status (admin only)
    /// </summary>
    [HttpPut("{id:int}/status")]
    [Authorize(Roles = IdentityRoleConstants.Admin)]
    [ProducesResponseType(typeof(BasicResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BasicResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateOrderStatus(int id, [FromBody] OrderUpdateStatusDto updateDto)
    {
        if (id <= 0)
            return BadRequest(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidId
            });

        if (!ModelState.IsValid)
        {
            var errorMessage = string.Join("; ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
            return BadRequest(new BasicResponse
            {
                Succeeded = false,
                Message = errorMessage
            });
        }

        var response = await _orderService.UpdateOrderStatusAsync(id, updateDto);
        if (response.Succeeded) return Ok(response);

        return NotFound(response);
    }

    /// <summary>
    ///     Update payment status (admin only)
    /// </summary>
    [HttpPut("{id:int}/payment-status")]
    [Authorize(Roles = IdentityRoleConstants.Admin)]
    [ProducesResponseType(typeof(BasicResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BasicResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdatePaymentStatus(int id, [FromBody] PaymentUpdateStatusDto updateDto)
    {
        if (id <= 0)
            return BadRequest(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidId
            });

        if (!ModelState.IsValid)
        {
            var errorMessage = string.Join("; ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
            return BadRequest(new BasicResponse
            {
                Succeeded = false,
                Message = errorMessage
            });
        }

        var response = await _orderService.UpdatePaymentStatusAsync(id, updateDto);
        if (response.Succeeded) return Ok(response);

        return NotFound(response);
    }
}