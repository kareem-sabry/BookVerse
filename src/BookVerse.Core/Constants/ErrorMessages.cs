namespace BookVerse.Core.Constants;

public static class ErrorMessages
{
    // User errors
    public const string UserNotFound = "User not found.";
    public const string UserAlreadyExists = "A user with this email already exists.";
    public const string InvalidCredentials = "Invalid email or password.";
    public const string InvalidUserContext = "Invalid user context.";
    public const string CannotModifyOwnAccount = "You cannot modify your own account.";
    public const string RegistrationFailed = "Registration failed.";
    public const string InvalidPasswordResetRequest = "Invalid password reset request.";
    public const string AccessDenied = "You do not have permission to access this resource.";

    // Role errors
    public const string InvalidRole = "Invalid role specified.";
    public const string RoleDoesNotExist = "The specified role does not exist.";
    public const string UserAlreadyAdmin = "User is already an admin.";
    public const string UserNotAdmin = "User is not an admin.";
    public const string CannotRegisterAsAdmin = "You can only register as a normal user.";

    // Token errors
    public const string RefreshTokenMissing = "Refresh token is missing.";
    public const string RefreshTokenExpired = "Refresh token has expired. Please log in again.";
    public const string RefreshTokenInvalid = "Invalid refresh token.";

    // General errors
    public const string InvalidId = "Invalid ID provided.";
    public const string OperationFailed = "The operation failed. Please try again.";
    public const string InternalServerError = "An unexpected error occurred. Please try again later.";

    // Entity errors
    public const string BookNotFound = "Book not found.";
    public const string AuthorNotFound = "Author not found.";
    public const string AuthorAlreadyExists = "An author with this name already exists.";
    public const string CategoryNotFound = "Category not found.";
    public const string CategoryAlreadyExists = "A category with this name already exists.";

    // Order Errors
    public const string OrderNotFound = "Order not found";
    public const string CannotUpdateTerminalOrderStatus = "Invalid order status transition";

    public const string EmptyCart = "Cannot create order from an empty cart.";
    public const string InsufficientStock = "Insufficient stock available for one or more items.";
    public const string CannotCancelOrder = "This order cannot be cancelled.";
    public const string CannotCancelOrderWithStatus = "Cannot cancel order with status: ";
    public const string InvalidOrderStatus = "Invalid order status.";
    public const string CartNotFound = "Cart not found.";
    public const string CartItemNotFound = "Cart item not found.";

    // Stripe / Payment Errors
    public const string StripePaymentIntentCreationFailed = "Failed to create Stripe payment intent.";
    public const string StripeWebhookSignatureInvalid = "Invalid Stripe webhook signature.";
    public const string StripeWebhookEventParsingFailed = "Failed to parse Stripe webhook event.";
    public const string PaymentIntentAlreadyExists = "Payment intent already exists for this order.";
    public const string StripeRetrievalFailed = "Payment retrieval failed.";
    public const string StripeRefundFailed = "Failed to process refund with Stripe.";

    public const string OrderMissingPaymentIntent =
        "Order does not have an associated payment intent and cannot be refunded.";

    public const string OrderNotInPendingPaymentStatus =
        "Payment can only be initiated for orders with pending payment status.";
}