using eCommerce.DTOs;

namespace eCommerce.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerResponseDTO>> GetAllAsync();
        Task<CustomerResponseDTO?> GetByIdAsync(int id);
        Task<CustomerResponseDTO> CreateAsync(CreateCustomerDTO createCustomer);
        Task<bool> UpdateAsync(int id, UpdateCustomerDTO updateCustomer);
        Task<bool> DeleteAsync(int id);
    }
}
