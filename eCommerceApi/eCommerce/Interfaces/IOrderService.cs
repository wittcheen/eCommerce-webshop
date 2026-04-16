using eCommerce.Models.DTOs;

namespace eCommerce.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponseDTO>> GetAllAsync();
        Task<OrderResponseDTO?> GetByIdAsync(int id);
        Task<OrderResponseDTO> CreateAsync(CreateOrderDTO createOrder);
        Task<bool> UpdateAsync(int id, UpdateOrderDTO updateOrder);
        Task<bool> DeleteAsync(int id);
    }
}
