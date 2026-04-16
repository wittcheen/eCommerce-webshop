using eCommerce.Data;
using eCommerce.Interfaces;
using eCommerce.Models;
using eCommerce.Models.DTOs;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DatabaseContext _context;

        public CustomerService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerResponseDTO>> GetAllAsync()
        {
            List<Customer> customers = await _context.Customers.ToListAsync();
            return customers.Adapt<IEnumerable<CustomerResponseDTO>>();
        }

        public async Task<CustomerResponseDTO?> GetByIdAsync(int id)
        {
            Customer? customer = await _context.Customers.FindAsync(id);
            return customer.Adapt<CustomerResponseDTO>();
        }

        public async Task<CustomerResponseDTO> CreateAsync(CreateCustomerDTO input)
        {
            Customer customer = input.Adapt<Customer>();

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return customer.Adapt<CustomerResponseDTO>();
        }

        public async Task<bool> UpdateAsync(int id, UpdateCustomerDTO input)
        {
            Customer? customer = await _context.Customers.FindAsync(id);
            if (customer == null) return false;

            input.Adapt(customer);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Customer? customer = await _context.Customers.FindAsync(id);
            if (customer == null) return false;
            
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
