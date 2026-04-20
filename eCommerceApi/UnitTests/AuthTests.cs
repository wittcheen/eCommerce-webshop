using eCommerce.Controllers;
using eCommerce.Interfaces;
using eCommerce.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTests
{
    public class AuthTests
    {
        private readonly Mock<IAuthService> _mockService;
        private readonly AuthController _controller;

        public AuthTests()
        {
            _mockService = new Mock<IAuthService>();
            _controller = new AuthController(_mockService.Object);
        }

        [Fact]
        public async Task Register_ReturnsOk_WhenSuccess()
        {
            AuthRegisterDTO register = new()
            {
                Name = "Test",
                Email = "test@email.com",
                Password = "Test123"
            };

            _mockService.Setup(s => s.RegisterAsync(register))
                .ReturnsAsync(true);
            var result = await _controller.Register(register);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Register_ReturnsConflict_WhenEmailExists()
        {
            AuthRegisterDTO register = new()
            {
                Name = "Test",
                Email = "test@email.com",
                Password = "Test123"
            };

            _mockService.Setup(s => s.RegisterAsync(register))
                .ReturnsAsync(false);
            var result = await _controller.Register(register);

            var conflict = Assert.IsType<ConflictObjectResult>(result);
            Assert.NotNull(conflict.Value);
        }

        [Fact]
        public async Task Login_ReturnsOk_WhenValidCredentials()
        {
            AuthLoginDTO login = new()
            {
                Email = "test@email.com",
                Password = "Test123"
            };

            AuthResponseDTO response = new()
            {
                AccessToken = "token"
            };

            _mockService.Setup(s => s.LoginAsync(login, It.IsAny<HttpResponse>()))
                .ReturnsAsync(response);
            var result = await _controller.Login(login);

            var ok = Assert.IsType<OkObjectResult>(result.Result);
            var data = Assert.IsType<AuthResponseDTO>(ok.Value);
            Assert.Equal(response.AccessToken, data.AccessToken);
        }

        [Fact]
        public async Task Login_ReturnsUnauthorized_WhenInvalidCredentials()
        {
            AuthLoginDTO login = new()
            {
                Email = "test@email.com",
                Password = "wrong"
            };

            _mockService.Setup(s => s.LoginAsync(login, It.IsAny<HttpResponse>()))
                .ReturnsAsync((AuthResponseDTO?)null);
            var result = await _controller.Login(login);

            Assert.IsType<UnauthorizedResult>(result.Result);
        }

        [Fact]
        public async Task Logout_ReturnsNoContent()
        {
            _controller.ControllerContext = new()
            {
                HttpContext = new DefaultHttpContext()
            };

            _mockService.Setup(s => s.LogoutAsync(It.IsAny<string>()))
                .Returns(Task.CompletedTask);
            var result = await _controller.Logout();

            Assert.IsType<NoContentResult>(result);
        }
    }
}
