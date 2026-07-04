using Asp.Versioning;
using BookVerse.Api.Extensions;
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

        var userId = User.GetUserId();
        if (userId == null)
            return Unauthorized(new BasicResponse
            {
                Succeeded = false,
                Message = ErrorMessages.InvalidUserContext
            });

        var result = await _paymentService.CreatePaymentIntentAsync(orderId, userId.Value, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Handle Stripe webhook events for payment intent status changes.
    /// </summary>
    [HttpPost("webhook")]
    [AllowAnonymous]
    [RequestSizeLimit(1_000_000)]
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