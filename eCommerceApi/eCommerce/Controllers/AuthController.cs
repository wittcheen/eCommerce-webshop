using eCommerce.Interfaces;
using eCommerce.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AuthRegisterDTO register)
        {
            bool result = await _service.RegisterAsync(register);
            if (result == false) return Conflict(new { Error = "This email is already in use." });

            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDTO>> Login(AuthLoginDTO login)
        {
            AuthResponseDTO? data = await _service.LoginAsync(login, Response);
            if (data == null) return Unauthorized();

            return Ok(data);
        }

        [HttpPost("refresh")]
        public async Task<ActionResult<AuthResponseDTO>> Refresh()
        {
            string? token = Request.Cookies["refreshToken"];
            if (token == null) return Unauthorized();

            AuthResponseDTO? data = await _service.RefreshAsync(token, Response);
            if (data == null) return Unauthorized();

            return Ok(data);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            string? token = Request.Cookies["refreshToken"];
            if (token == null) return NoContent();

            await _service.LogoutAsync(token);
            Response.Cookies.Delete("refreshToken");
            return NoContent();
        }
    }
}
