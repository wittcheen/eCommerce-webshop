using eCommerce.Data;
using eCommerce.DTOs;
using eCommerce.Interfaces;

namespace eCommerce.Services
{
    public class ProductService : IProductService
    {
        private readonly DatabaseContext _context;

        public ProductService(DatabaseContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<ProductResponseDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductResponseDTO?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductResponseDTO> CreateAsync(CreateProductDTO createProduct)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, UpdateProductDTO updateProduct)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
