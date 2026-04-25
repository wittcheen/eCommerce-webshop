using eCommerce.Data;
using eCommerce.Interfaces;
using eCommerce.Models;
using eCommerce.Models.DTOs;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Services
{
    public class ProductService : IProductService
    {
        private readonly DatabaseContext _context;

        public ProductService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductResponseDTO>> SearchAsync(int? categoryId)
        {
            IQueryable<Product> query = _context.Products
                .Include(p => p.Images);

            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryID == categoryId);
            }

            List<Product> products = await query.ToListAsync();
            return products.Adapt<IEnumerable<ProductResponseDTO>>();
        }

        public Task<IEnumerable<ProductResponseDTO>> GetAllAsync()
        {
            throw new NotImplementedException();

            //List<Product> products = await _context.Products.ToListAsync();
            //return products.Adapt<IEnumerable<ProductResponseDTO>>();
        }

        public async Task<ProductResponseDTO?> GetByIdAsync(int id)
        {
            Product? product = await _context.Products
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.ProductID == id);
            return product.Adapt<ProductResponseDTO>();
        }

        public async Task<ProductResponseDTO> CreateAsync(CreateProductDTO input)
        {
            if (!CategoryExists(input.CategoryID)) return new();

            Product product = input.Adapt<Product>();

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product.Adapt<ProductResponseDTO>();
        }

        public async Task<bool> UpdateAsync(int id, UpdateProductDTO input)
        {
            if (!CategoryExists(input.CategoryID)) return new();

            Product? product = await _context.Products
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.ProductID == id);
            if (product == null) return false;

            input.Adapt(product);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Product? product = await _context.Products
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.ProductID == id);
            if (product == null) return false;

            _context.Images.RemoveRange(product.Images);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool CategoryExists(int id)
        {
            return (_context.Categories?.Any(c => c.CategoryID == id)).GetValueOrDefault();
        }
    }
}
