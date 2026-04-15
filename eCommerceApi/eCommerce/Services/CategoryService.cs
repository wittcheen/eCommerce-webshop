using eCommerce.Data;
using eCommerce.DTOs;
using eCommerce.Interfaces;
using eCommerce.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly DatabaseContext _context;

        public CategoryService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryResponseDTO>> GetAllAsync()
        {
            List<Category> categories = await _context.Categories.ToListAsync();
            return categories.Adapt<IEnumerable<CategoryResponseDTO>>();
        }

        public async Task<CategoryResponseDTO?> GetByIdAsync(int id)
        {
            Category? category = await _context.Categories.FindAsync(id);
            return category.Adapt<CategoryResponseDTO>();
        }

        public async Task<CategoryResponseDTO> CreateAsync(CreateCategoryDTO createCategory)
        {
            Category category = createCategory.Adapt<Category>();

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return category.Adapt<CategoryResponseDTO>();
        }

        public async Task<bool> UpdateAsync(int id, UpdateCategoryDTO updateCategory)
        {
            Category? category = await _context.Categories.FindAsync(id);
            if (category == null) return false;

            updateCategory.Adapt(category);
            await _context.SaveChangesAsync();
            
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Category? category = await _context.Categories.FindAsync(id);
            if (category == null) return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
