using eCommerce.Models.DTOs;

namespace eCommerce.Interfaces
{
    public interface ICustomerService : IGeneric<CustomerResponseDTO, CreateCustomerDTO, UpdateCustomerDTO>
    {

    }
}
