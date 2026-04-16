using eCommerce.Data;
using eCommerce.Interfaces;
using eCommerce.Models;
using eCommerce.Models.DTOs;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Services
{
    public class ImageService : IImageService
    {
        private readonly DatabaseContext _context;

        public ImageService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ImageResponseDTO>> GetAllAsync()
        {
            List<Image> images = await _context.Images.ToListAsync();
            return images.Adapt<IEnumerable<ImageResponseDTO>>();
        }

        public async Task<ImageResponseDTO?> GetByIdAsync(int id)
        {
            Image? image = await _context.Images.FindAsync(id);
            return image.Adapt<ImageResponseDTO>();
        }

        public async Task<ImageResponseDTO> CreateAsync(CreateImageDTO createImage)
        {
            Image image = createImage.Adapt<Image>();

            _context.Images.Add(image);
            await _context.SaveChangesAsync();

            return image.Adapt<ImageResponseDTO>();
        }

        public async Task<bool> UpdateAsync(int id, UpdateImageDTO updateImage)
        {
            Image? image = await _context.Images.FindAsync(id);
            if (image == null) return false;

            updateImage.Adapt(image);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Image? image = await _context.Images.FindAsync(id);
            if (image == null) return false;

            _context.Images.Remove(image);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
