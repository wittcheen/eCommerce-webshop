using eCommerce.Models.DTOs;

namespace eCommerce.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponseDTO>> GetAllAsync();
        Task<CategoryResponseDTO?> GetByIdAsync(int id);
        Task<CategoryResponseDTO> CreateAsync(CreateCategoryDTO createCategory);
        Task<bool> UpdateAsync(int id, UpdateCategoryDTO updateCategory);
        Task<bool> DeleteAsync(int id);
    }
}
