using eCommerce.Models.DTOs;

namespace eCommerce.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(AuthRegisterDTO input);
        Task<AuthResponseDTO?> LoginAsync(AuthLoginDTO input, HttpResponse response);
        Task<AuthResponseDTO?> RefreshAsync(string refreshToken, HttpResponse response);
        Task LogoutAsync(string refreshToken);
    }
}
