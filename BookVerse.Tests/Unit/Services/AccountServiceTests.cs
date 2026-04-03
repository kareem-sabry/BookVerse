using BookVerse.Application.Dtos.User;
using BookVerse.Application.Interfaces;
using BookVerse.Core.Constants;
using BookVerse.Core.Entities;
using BookVerse.Core.Enums;
using BookVerse.Infrastructure.Services;
using BookVerse.Tests.Helpers;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Moq;

namespace BookVerse.Tests.Unit.Services;

public class AccountServiceTests
{
    private readonly Mock<IDateTimeProvider> _mockDateTimeProvider;
    private readonly Mock<IEmailService> _mockEmailService;
    private readonly Mock<ILogger<AccountService>> _mockLogger;
    private readonly Mock<RoleManager<IdentityRole<Guid>>> _mockRoleManager;
    private readonly Mock<IAuthTokenProcessor> _mockTokenProcessor;
    private readonly Mock<UserManager<User>> _mockUserManager;
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly AccountService _sut;

    public AccountServiceTests()
    {
        _mockUserManager = TestHelper.MockUserManager();
        _mockRoleManager = TestHelper.MockRoleManager();
        _mockUserRepository = new Mock<IUserRepository>();
        _mockEmailService = new Mock<IEmailService>();
        _mockLogger = new Mock<ILogger<AccountService>>();
        _mockTokenProcessor = new Mock<IAuthTokenProcessor>();
        _mockDateTimeProvider = new Mock<IDateTimeProvider>();

        //Default date for all tests
        _mockDateTimeProvider.Setup(x => x.UtcNow)
            .Returns(new DateTime(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc));

        _sut = new AccountService(
            _mockTokenProcessor.Object,
            _mockUserManager.Object,
            _mockRoleManager.Object,
            _mockUserRepository.Object,
            _mockEmailService.Object,
            _mockLogger.Object,
            _mockDateTimeProvider.Object);
    }

    #region RegisterAsync Tests

    [Fact]
    public async Task RegisterAsync_WithValidData_ReturnsSuccess()
    {
        // Arrange
        var request = new RegisterRequest
        {
            Email = "newuser@test.com",
            FirstName = "John",
            LastName = "Doe",
            Password = "Password123!",
            Role = Role.User
        };

        _mockUserManager.Setup(x => x.FindByEmailAsync(request.Email)).ReturnsAsync((User?)null);

        _mockRoleManager.Setup(x => x.RoleExistsAsync(IdentityRoleConstants.User)).ReturnsAsync(true);

        _mockUserManager.Setup(x => x.CreateAsync(It.IsAny<User>(), request.Password))
            .ReturnsAsync(IdentityResult.Success);


        _mockUserManager.Setup(x => x.AddToRoleAsync(It.IsAny<User>(), IdentityRoleConstants.User))
            .ReturnsAsync(IdentityResult.Success);

        // Act
        var registerResult = await _sut.RegisterAsync(request);

        // Assert
        registerResult.Succeeded.Should().BeTrue();
        registerResult.Message.Should().Be(SuccessMessages.RegistrationSuccessful);
        registerResult.Errors.Should().BeEmpty();


        _mockUserManager.Verify(x => x.CreateAsync(
            It.Is<User>(u =>
                u.Email == request.Email &&
                u.FirstName == request.FirstName &&
                u.LastName == request.LastName &&
                u.CreatedAtUtc == _mockDateTimeProvider.Object.UtcNow)
            , request.Password), Times.Once);

        _mockUserManager.Verify(x => x.AddToRoleAsync(It.IsAny<User>(),
            IdentityRoleConstants.User), Times.Once);
    }

    [Fact]
    public async Task RegisterAsync_WithExistingEmail_ReturnsFailure()
    {
        // Arrange
        var request = new RegisterRequest
        {
            Email = "newuser@test.com",
            FirstName = "John",
            LastName = "Doe",
            Password = "Password123!",
            Role = Role.User
        };

        var existingUser = new User
        {
            Email = request.Email,
            FirstName = "Jane",
            LastName = "Smith"
        };
        _mockUserManager.Setup(x => x.FindByEmailAsync(request.Email)).ReturnsAsync(existingUser);

        // Act
        var registerResult = await _sut.RegisterAsync(request);

        // Assert
        registerResult.Succeeded.Should().BeFalse();
        registerResult.Message.Should().Be(ErrorMessages.UserAlreadyExists);
        registerResult.Errors.Should().Contain(ErrorMessages.UserAlreadyExists);

        _mockUserManager.Verify(x => x.CreateAsync(
            It.IsAny<User>(), It.IsAny<string>()), Times.Never);

        _mockUserManager.Verify(x => x.AddToRoleAsync(It.IsAny<User>(),
            IdentityRoleConstants.User), Times.Never);
    }

    [Fact]
    public async Task RegisterAsync_WithAdminRole_ReturnsFailure()
    {
        // Arrange
        var request = new RegisterRequest
        {
            Email = "newuser@test.com",
            FirstName = "John",
            LastName = "Doe",
            Password = "Password123!",
            Role = Role.Admin
        };

        _mockUserManager.Setup(x => x.FindByEmailAsync(request.Email)).ReturnsAsync((User?)null);

        // Act
        var registerResult = await _sut.RegisterAsync(request);
        // Assert
        registerResult.Succeeded.Should().BeFalse();
        registerResult.Message.Should().Be(ErrorMessages.InvalidRole);
        registerResult.Errors.Contains(ErrorMessages.CannotRegisterAsAdmin);

        _mockUserManager.Verify(x => x.CreateAsync(It.IsAny<User>(), It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public async Task RegisterAsync_WhenRoleDoesNotExist_ReturnsFailure()
    {
        // Arrange
        var request = new RegisterRequest
        {
            Email = "newuser@test.com",
            FirstName = "John",
            LastName = "Doe",
            Password = "Password123!",
            Role = Role.User
        };

        _mockUserManager.Setup(x => x.FindByEmailAsync(request.Email)).ReturnsAsync((User?)null);

        _mockRoleManager.Setup(x => x.RoleExistsAsync(IdentityRoleConstants.User)).ReturnsAsync(false);

        // Act
        var registerResult = await _sut.RegisterAsync(request);

        // Assert
        registerResult.Succeeded.Should().Be(false);
        registerResult.Message.Should().Be(ErrorMessages.InvalidRole);
        registerResult.Message.Should().Contain(ErrorMessages.InvalidRole);

        _mockUserManager.Verify(x => x.CreateAsync(It.IsAny<User>(), It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public async Task RegisterAsync_WhenUserCreationFails_ReturnsFailure()
    {
        // Arrange
        var request = new RegisterRequest
        {
            Email = "newuser@test.com",
            FirstName = "John",
            LastName = "Doe",
            Password = "123",
            Role = Role.User
        };

        _mockUserManager.Setup(x => x.FindByEmailAsync(request.Email)).ReturnsAsync((User?)null);

        _mockRoleManager.Setup(x => x.RoleExistsAsync(IdentityRoleConstants.User)).ReturnsAsync(true);

        var identityErrors = new[]
        {
            new IdentityError { Description = "Password is too weak!" }
        };
        _mockUserManager.Setup(x => x.CreateAsync(It.IsAny<User>(), request.Password))
            .ReturnsAsync(IdentityResult.Failed(identityErrors));

        // Act
        var registerResult = await _sut.RegisterAsync(request);

        // Assert
        registerResult.Succeeded.Should().Be(false);
        registerResult.Message.Should().Be(ErrorMessages.RegistrationFailed);
        registerResult.Errors.Should().Contain("Password is too weak!");

        _mockUserManager.Verify(x => x.AddToRoleAsync(It.IsAny<User>(), It.IsAny<string>()), Times.Never());
    }

    #endregion

    #region LoginAsync Tests

    [Fact]
    public async Task LoginAsync_WithValidCredentials_ReturnsSuccessWithTokens()
    {
        // Arrange
        var loginRequest = new LoginRequest
        {
            Email = "user@test.com",
            Password = "Password123!"
        };
        var existingUser = new User
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Doe",
            Email = loginRequest.Email
        };

        var jwtToken = "fake-token-for-testing";

        var refreshToken = "Also-fake-token-for-testing";

        var userRoles = new List<string> { IdentityRoleConstants.User };

        var expiresAt = _mockDateTimeProvider.Object.UtcNow.AddMinutes(60);

        _mockUserManager.Setup(x => x.FindByEmailAsync(loginRequest.Email)).ReturnsAsync(existingUser);

        _mockUserManager.Setup(x => x.CheckPasswordAsync(existingUser, loginRequest.Password)).ReturnsAsync(true);

        _mockUserManager.Setup(x => x.GetRolesAsync(existingUser)).ReturnsAsync(userRoles);

        _mockTokenProcessor.Setup(x => x.GenerateJwtToken(existingUser, userRoles)).Returns((jwtToken, expiresAt));

        _mockTokenProcessor.Setup(x => x.GenerateRefreshToken()).Returns(refreshToken);

        _mockUserManager.Setup(x => x.UpdateAsync(existingUser)).ReturnsAsync(IdentityResult.Success);

        // Act

        var loginResult = await _sut.LoginAsync(loginRequest);

        // Assert
        loginResult.Succeeded.Should().Be(true);
        loginResult.Message.Should().Be(SuccessMessages.LoginSuccessful);
        loginResult.AccessToken.Should().Be(jwtToken);
        loginResult.RefreshToken.Should().Be(refreshToken);
        loginResult.ExpiresAtUtc.Should().Be(expiresAt);
        loginResult.ExpiresAtUtc.Should().Be(expiresAt);

        existingUser.RefreshToken.Should().Be(refreshToken);
        existingUser.RefreshTokenExpiresAtUtc.Should().NotBeNull();

        _mockUserManager.Verify(x => x.UpdateAsync(existingUser), Times.Once);
    }

    [Fact]
    public async Task LoginAsync_WithInvalidEmail_ReturnsFailure()
    {
        // Arrange
        var loginRequest = new LoginRequest
        {
            Email = "nonexistant@test.com",
            Password = "Password123!"
        };

        _mockUserManager.Setup(x => x.FindByEmailAsync(loginRequest.Email)).ReturnsAsync((User?)null);

        // Act
        var result = await _sut.LoginAsync(loginRequest);

        // Assert
        result.Succeeded.Should().BeFalse();
        result.Message.Should().Be(ErrorMessages.InvalidCredentials);
        result.AccessToken.Should().BeNull();
        result.RefreshToken.Should().BeNull();
    }

    [Fact]
    public async Task LoginAsync_WithInvalidPassword_ReturnsFailure()
    {
        // Arrange
        var loginRequest = new LoginRequest
        {
            Email = "test@test.com",
            Password = "WrongPasswrod"
        };

        var existingUser = new User
        {
            FirstName = "John",
            LastName = "Doe",
            Email = loginRequest.Email
        };
        _mockUserManager.Setup(x => x.FindByEmailAsync(loginRequest.Email)).ReturnsAsync(existingUser);

        _mockUserManager.Setup(x => x.CheckPasswordAsync(existingUser, loginRequest.Password)).ReturnsAsync(false);

        // Act
        var loginResult = await _sut.LoginAsync(loginRequest);


        // Assert
        loginResult.Succeeded.Should().BeFalse();
        loginResult.Message.Should().Be(ErrorMessages.InvalidCredentials);

        _mockTokenProcessor.Verify(x => x.GenerateJwtToken(It.IsAny<User>(), It.IsAny<IList<string>>()), Times.Never);
    }

    #endregion

    #region RefreshTokenAsync Tests

    [Fact]
    public async Task RefreshTokenAsync_WithValidToken_ReturnsNewTokens()
    {
        // Arrange
        var token = "valid-refresh-token";

        var request = new RefreshTokenRequest
        {
            RefreshToken = token
        };

        var userRoles = new List<string> { IdentityRoleConstants.User };
        var existingUser = new User
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Doe",
            Email = "test@test.com",
            RefreshToken = token,
            RefreshTokenExpiresAtUtc = _mockDateTimeProvider.Object.UtcNow.AddDays(1)
        };

        var newJwtToken = "new-generated-token";
        var expirationDateInUtc = _mockDateTimeProvider.Object.UtcNow.AddMinutes(15);

        var newRefreshToken = "new-refresh-token";

        _mockUserRepository.Setup(x => x.GetUserByRefreshTokenAsync(request.RefreshToken, It.IsAny<CancellationToken>())).ReturnsAsync(existingUser);

        _mockUserManager.Setup(x => x.GetRolesAsync(existingUser)).ReturnsAsync(userRoles);

        _mockTokenProcessor.Setup(x => x.GenerateJwtToken(existingUser, userRoles))
            .Returns((newJwtToken, expirationDateInUtc));

        _mockTokenProcessor.Setup(x => x.GenerateRefreshToken()).Returns(newRefreshToken);

        _mockUserManager.Setup(x => x.UpdateAsync(existingUser)).ReturnsAsync(IdentityResult.Success);

        // Act
        var result = await _sut.RefreshTokenAsync(request, It.IsAny<CancellationToken>());

        // Assert
        result.Succeeded.Should().BeTrue();
        result.Message.Should().Be(SuccessMessages.TokenRefreshed);
        result.AccessToken.Should().Be(newJwtToken);
        result.ExpiresAtUtc.Should().Be(expirationDateInUtc);
        result.RefreshToken.Should().Be(newRefreshToken);
    }

    [Fact]
    public async Task RefreshTokenAsync_WithExpiredToken_ReturnsFailure()
    {
        // Arrange
        var token = "valid-refresh-token";

        var request = new RefreshTokenRequest
        {
            RefreshToken = token
        };

        var userRoles = new List<string> { IdentityRoleConstants.User };
        var existingUser = new User
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Doe",
            Email = "test@test.com",
            RefreshToken = token,
            RefreshTokenExpiresAtUtc = _mockDateTimeProvider.Object.UtcNow.AddDays(-1)
        };


        _mockUserRepository.Setup(x => x.GetUserByRefreshTokenAsync(request.RefreshToken, It.IsAny<CancellationToken>())).ReturnsAsync(existingUser);

        _mockUserManager.Setup(x => x.GetRolesAsync(existingUser)).ReturnsAsync(userRoles);

        // Act
        var result = await _sut.RefreshTokenAsync(request, It.IsAny<CancellationToken>());

        // Assert
        result.Succeeded.Should().BeFalse();
        result.Message.Should().Be(ErrorMessages.RefreshTokenExpired);
    }

    #endregion
}