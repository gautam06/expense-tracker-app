namespace ExpenseTrackerAPI.Tests.Controllers
{
    public class AuthControllerTests
    {
        private readonly Mock<IAuthService> _authServiceMock;
        private readonly AuthController _controller;

        public AuthControllerTests()
        {
            _authServiceMock = new Mock<IAuthService>();
            _controller = new AuthController(_authServiceMock.Object);
        }

        [Fact]
        public async Task SignIn_ShouldReturnBadRequest_WhenUsernameOrPasswordIsEmpty()
        {
            // Arrange
            var request = new SigninRequest { Username = "", Password = "" };

            // Act
            var result = await _controller.SignIn(request);

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Username and Password cannot be empty.", actionResult.Value);
        }

        [Fact]
        public async Task SignIn_ShouldReturnUnauthorized_WhenUserNotFound()
        {
            // Arrange
            var request = new SigninRequest { Username = "test", Password = "password" };
            _authServiceMock.Setup(x => x.AuthenticateAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync((UserDetail)null);

            // Act
            var result = await _controller.SignIn(request);

            // Assert
            var actionResult = Assert.IsType<UnauthorizedObjectResult>(result);
            Assert.Equal("Invalid username or password.", actionResult.Value);
        }
        
    }
}
