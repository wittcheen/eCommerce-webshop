using eCommerce.Data;
using eCommerce.DTOs;
using eCommerce.Interfaces;

namespace eCommerce.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly DatabaseContext _context;

        public CategoryService(DatabaseContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<CategoryResponseDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryResponseDTO?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryResponseDTO> CreateAsync(CreateCategoryDTO createCategory)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, UpdateCategoryDTO updateCategory)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
