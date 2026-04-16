using eCommerce.Models.DTOs;

namespace eCommerce.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDTO>> GetAllAsync();
        Task<ProductResponseDTO?> GetByIdAsync(int id);
        Task<ProductResponseDTO> CreateAsync(CreateProductDTO createProduct);
        Task<bool> UpdateAsync(int id, UpdateProductDTO updateProduct);
        Task<bool> DeleteAsync(int id);
    }
}
