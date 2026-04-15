using eCommerce.Data;
using eCommerce.DTOs;
using eCommerce.Interfaces;

namespace eCommerce.Services
{
    public class ImageService : IImageService
    {
        private readonly DatabaseContext _context;

        public ImageService(DatabaseContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<ImageResponseDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ImageResponseDTO?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ImageResponseDTO> CreateAsync(CreateImageDTO createImage)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, UpdateImageDTO updateImage)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
