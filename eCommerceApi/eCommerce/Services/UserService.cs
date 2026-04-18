using eCommerce.Data;
using eCommerce.Interfaces;
using eCommerce.Models;
using eCommerce.Models.DTOs;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Services
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _context;

        public UserService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserResponseDTO>> GetAllAsync()
        {
            List<User> users = await _context.Users.ToListAsync();
            return users.Adapt<IEnumerable<UserResponseDTO>>();
        }

        public async Task<UserResponseDTO?> GetByIdAsync(int id)
        {
            User? user = await _context.Users.FindAsync(id);
            return user.Adapt<UserResponseDTO>();
        }

        public Task<UserResponseDTO> CreateAsync(CreateUserDTO input)
        {
            throw new NotImplementedException();

            //User user = input.Adapt<User>();

            //_context.Users.Add(user);
            //await _context.SaveChangesAsync();

            //return user.Adapt<UserResponseDTO>();
        }

        public async Task<bool> UpdateAsync(int id, UpdateUserDTO input)
        {
            User? user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            input.Adapt(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            User? user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
