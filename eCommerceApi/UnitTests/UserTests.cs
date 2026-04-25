using eCommerce.Controllers;
using eCommerce.Interfaces;
using eCommerce.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTests
{
    public class UserTests
    {
        private readonly Mock<IUserService> _mockService;
        private readonly UsersController _controller;

        public UserTests()
        {
            _mockService = new Mock<IUserService>();
            _controller = new UsersController(_mockService.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOk_WithListOfUsers()
        {
            List<UserResponseDTO> users = new()
            {
                new UserResponseDTO { ID = 1, Name = "Test", Email = "test@email.com" },
                new UserResponseDTO { ID = 2, Name = "Test1", Email = "test1@email.com" }
            };

            _mockService.Setup(s => s.GetAllAsync())
                .ReturnsAsync(users);
            var result = await _controller.GetAll();

            var ok = Assert.IsType<OkObjectResult>(result.Result);
            var data = Assert.IsAssignableFrom<IEnumerable<UserResponseDTO>>(ok.Value);

            Assert.Equal(users.Count, data.Count());
            Assert.Equal(users.First().Email, data.First().Email);
            Assert.Equal(users.Last().Email, data.Last().Email);
        }

        [Fact]
        public async Task GetById_ReturnsOk_WhenUserExists()
        {
            UserResponseDTO user = new()
            {
                ID = 1,
                Name = "Test",
                Email = "test@email.com"
            };

            _mockService.Setup(s => s.GetByIdAsync(user.ID))
                .ReturnsAsync(user);
            var result = await _controller.GetById(user.ID);

            var ok = Assert.IsType<OkObjectResult>(result.Result);
            var data = Assert.IsType<UserResponseDTO>(ok.Value);

            Assert.Equal(user.ID, data.ID);
            Assert.Equal(user.Email, data.Email);
        }

        [Fact]
        public async Task GetById_ReturnsNotFound_WhenUserDoesNotExist()
        {
            int userId = 3;

            _mockService.Setup(s => s.GetByIdAsync(userId))
                .ReturnsAsync((UserResponseDTO?)null);
            var result = await _controller.GetById(userId);

            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
