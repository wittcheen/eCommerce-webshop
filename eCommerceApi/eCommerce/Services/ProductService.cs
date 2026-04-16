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

        public async Task<IEnumerable<ProductResponseDTO>> GetAllAsync()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return products.Adapt<IEnumerable<ProductResponseDTO>>();
        }

        public async Task<ProductResponseDTO?> GetByIdAsync(int id)
        {
            Product? product = await _context.Products.FindAsync(id);
            return product.Adapt<ProductResponseDTO>();
        }

        public async Task<ProductResponseDTO> CreateAsync(CreateProductDTO input)
        {
            Product product = input.Adapt<Product>();

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product.Adapt<ProductResponseDTO>();
        }

        public async Task<bool> UpdateAsync(int id, UpdateProductDTO input)
        {
            Product? product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            input.Adapt(product);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Product? product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
