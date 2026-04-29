using BookVerse.Application.Interfaces;
using BookVerse.Core.Constants;
using BookVerse.Core.Enums;
using BookVerse.Core.Exceptions;
using BookVerse.Core.Models;
using BookVerse.Infrastructure.Services;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Stripe;
using Order = BookVerse.Core.Entities.Order;

namespace BookVerse.Tests.Unit.Services;

public class PaymentServiceTests
{
    private readonly Mock<ILogger<PaymentService>> _mockLogger;
    private readonly Mock<IOrderRepository> _mockOrderRepository;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<IStripePaymentIntentService> _mockStripePaymentIntentService;
    private readonly Mock<IStripeWebhookConstructor> _mockWebhookConstructor;
    private readonly PaymentService _sut;

    public PaymentServiceTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockLogger = new Mock<ILogger<PaymentService>>();
        _mockOrderRepository = new Mock<IOrderRepository>();
        _mockStripePaymentIntentService = new Mock<IStripePaymentIntentService>();
        _mockWebhookConstructor = new Mock<IStripeWebhookConstructor>();
        _mockUnitOfWork.Setup(x => x.Orders).Returns(_mockOrderRepository.Object);

        var stripeOptions = Options.Create(new StripeOptions
        {
            SecretKey = "sk_test_fake",
            PublishableKey = "pk_test_fake",
            WebhookSecret = "whsec_fake"
        });

        _sut = new PaymentService(
            _mockUnitOfWork.Object,
            stripeOptions,
            _mockLogger.Object,
            _mockStripePaymentIntentService.Object,
            _mockWebhookConstructor.Object);
    }

    #region CreatePaymentIntentAsync Tests

    [Fact]
    public async Task CreatePaymentIntentAsync_WithNonExistentOrder_ThrowsNotFoundException()
    {
        // Arrange
        var orderId = 999;
        var userId = Guid.NewGuid();

        _mockOrderRepository
            .Setup(x => x.GetByIdAsync(orderId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Order?)null);

        // Act
        var act = async () =>
            await _sut.CreatePaymentIntentAsync(orderId, userId);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>()
            .WithMessage(ErrorMessages.OrderNotFound);
    }

    [Fact]
    public async Task CreatePaymentIntentAsync_WhenOrderBelongsToDifferentUser_ThrowsForbiddenException()
    {
        // Arrange
        var orderId = 1;
        var requestingUserId = Guid.NewGuid();
        var ownerUserId = Guid.NewGuid(); // different user

        var order = new Order
        {
            Id = orderId,
            UserId = ownerUserId,
            PaymentStatus = PaymentStatus.Pending,
            TotalAmount = 50.00m
        };

        _mockOrderRepository
            .Setup(x => x.GetByIdAsync(orderId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(order);

        // Act
        var act = async () =>
            await _sut.CreatePaymentIntentAsync(orderId, requestingUserId);

        // Assert
        await act.Should().ThrowAsync<ForbiddenException>();
    }

    [Fact]
    public async Task CreatePaymentIntentAsync_WhenOrderAlreadyPaid_ThrowsValidationException()
    {
        // Arrange
        var orderId = 1;
        var userId = Guid.NewGuid();

        var order = new Order
        {
            Id = orderId,
            UserId = userId,
            PaymentStatus = PaymentStatus.Completed, // already paid
            TotalAmount = 50.00m
        };

        _mockOrderRepository
            .Setup(x => x.GetByIdAsync(orderId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(order);

        // Act
        var act = async () =>
            await _sut.CreatePaymentIntentAsync(orderId, userId);

        // Assert
        await act.Should().ThrowAsync<ValidationException>()
            .WithMessage(ErrorMessages.OrderNotInPendingPaymentStatus);
    }

    #endregion

    #region HandleWebhookAsync — Idempotency Tests

    private static Event BuildFakeEvent(string eventType, string paymentIntentId)
    {
        var paymentIntent = new PaymentIntent
        {
            Id = paymentIntentId
        };

        return new Event
        {
            Type = eventType,
            Data = new EventData { Object = paymentIntent }
        };
    }

    [Fact]
    public async Task HandleWebhookAsync_WhenOrderAlreadyCompleted_IsNoOp()
    {
        // Arrange
        var paymentIntentId = "pi_already_processed";
        var fakeEvent = BuildFakeEvent(EventTypes.PaymentIntentSucceeded, paymentIntentId);

        _mockWebhookConstructor
            .Setup(x => x.ConstructEvent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
            .Returns(fakeEvent);

        var order = new Order
        {
            Id = 1,
            OrderNumber = "ORD-20250101-000001",
            PaymentStatus = PaymentStatus.Completed,
            Status = OrderStatus.Processing,
            StripePaymentIntentId = paymentIntentId
        };

        _mockOrderRepository
            .Setup(x => x.GetByStripePaymentIntentIdAsync(paymentIntentId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(order);

        // Act — calls the real service method
        await _sut.HandleWebhookAsync("raw_body", "stripe_sig", CancellationToken.None);

        // Assert — idempotency guard must fire; no updates allowed
        _mockOrderRepository.Verify(x => x.Update(It.IsAny<Order>()), Times.Never);
        _mockUnitOfWork.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task HandleWebhookAsync_WhenOrderAlreadyFailed_IsNoOp()
    {
        // Arrange
        var paymentIntentId = "pi_already_failed";
        var fakeEvent = BuildFakeEvent(EventTypes.PaymentIntentPaymentFailed, paymentIntentId);

        _mockWebhookConstructor
            .Setup(x => x.ConstructEvent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
            .Returns(fakeEvent);

        var order = new Order
        {
            Id = 1,
            OrderNumber = "ORD-20250101-000002",
            PaymentStatus = PaymentStatus.Failed,
            StripePaymentIntentId = paymentIntentId
        };

        _mockOrderRepository
            .Setup(x => x.GetByStripePaymentIntentIdAsync(paymentIntentId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(order);

        // Act
        await _sut.HandleWebhookAsync("raw_body", "stripe_sig", CancellationToken.None);

        // Assert
        _mockOrderRepository.Verify(x => x.Update(It.IsAny<Order>()), Times.Never);
        _mockUnitOfWork.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task HandleWebhookAsync_WhenOrderNotFound_ReturnsGracefully()
    {
        // Arrange
        var paymentIntentId = "pi_no_matching_order";
        var fakeEvent = BuildFakeEvent(EventTypes.PaymentIntentSucceeded, paymentIntentId);

        _mockWebhookConstructor
            .Setup(x => x.ConstructEvent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
            .Returns(fakeEvent);

        _mockOrderRepository
            .Setup(x => x.GetByStripePaymentIntentIdAsync(paymentIntentId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Order?)null);

        // Act — should log warning and return without throwing
        await _sut.HandleWebhookAsync("raw_body", "stripe_sig", CancellationToken.None);

        // Assert
        _mockOrderRepository.Verify(x => x.Update(It.IsAny<Order>()), Times.Never);
        _mockUnitOfWork.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    #endregion
}