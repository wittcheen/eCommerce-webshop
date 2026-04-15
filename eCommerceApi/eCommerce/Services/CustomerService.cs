using eCommerce.Data;
using eCommerce.DTOs;
using eCommerce.Interfaces;

namespace eCommerce.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DatabaseContext _context;

        public CustomerService(DatabaseContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<CustomerResponseDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerResponseDTO?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerResponseDTO> CreateAsync(CreateCustomerDTO createCustomer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, UpdateCustomerDTO updateCustomer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
