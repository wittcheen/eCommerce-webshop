using eCommerce.DTOs;

namespace eCommerce.Interfaces
{
    public interface IImageService
    {
        Task<IEnumerable<ImageResponseDTO>> GetAllAsync();
        Task<ImageResponseDTO?> GetByIdAsync(int id);
        Task<ImageResponseDTO> CreateAsync(CreateImageDTO createImage);
        Task<bool> UpdateAsync(int id, UpdateImageDTO updateImage);
        Task<bool> DeleteAsync(int id);
    }
}
