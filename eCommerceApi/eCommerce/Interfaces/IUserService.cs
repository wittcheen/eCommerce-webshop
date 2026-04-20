using eCommerce.Models.DTOs;

namespace eCommerce.Interfaces
{
    public interface IUserService : IGeneric<UserResponseDTO, CreateUserDTO, UpdateUserDTO>
    {
        Task<bool> ChangePasswordAsync(int id, string newPassword);
    }
}
