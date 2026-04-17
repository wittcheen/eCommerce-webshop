using eCommerce.Models.DTOs;

namespace eCommerce.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(UserResponseDTO user);
        string GenerateRefreshToken();
    }
}
