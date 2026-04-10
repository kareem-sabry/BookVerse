using System.Security.Claims;
using Asp.Versioning;
using BookVerse.Application.Dtos.Payment;
using BookVerse.Application.Dtos.User;
using BookVerse.Application.Interfaces;
using BookVerse.Core.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookVerse.Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[Produces("application/json")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    /// <summary>
    /// Create a Stripe PaymentIntent for the specified order.
    /// </summary>
    /// <param name="orderId">The ID of the order to pay for.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>PaymentIntent response containing client secret and publishable key.</returns>
    /// <response code="200">Payment intent created successfully.</response>
    /// <response code="400">Order payment status is not pending or request is invalid.</response>
    /// <response code="403">Order does not belong to the authenticated user.</response>
    /// <response code="404">Order not found.</response>
    [HttpPost("create-intent/{orderId}")]
    [Authorize]
    [ProducesResponseType(typeof(PaymentIntentResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BasicResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreatePaymentIntent(int orderId, CancellationToken cancellationToken = default)
    {
        if (orderId <= 0)
            return BadRequest(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidId
            });

        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId))
            return Unauthorized(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidUserContext
            });

        var result = await _paymentService.CreatePaymentIntentAsync(orderId, userId, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Handle Stripe webhook events for payment intent status changes.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <response code="200">Webhook processed successfully.</response>
    [HttpPost("webhook")]
    [AllowAnonymous]
    [DisableRequestSizeLimit]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> HandleWebhook(CancellationToken cancellationToken = default)
    {
        using var reader = new StreamReader(Request.Body);
        var json = await reader.ReadToEndAsync(cancellationToken);
        var stripeSignature = Request.Headers["Stripe-Signature"].ToString();

        await _paymentService.HandleWebhookAsync(json, stripeSignature, cancellationToken);
        return Ok();
    }
}
