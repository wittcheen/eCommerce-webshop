using eCommerce.DTOs;

namespace eCommerce.Interfaces
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItemResponseDTO>> GetAllAsync();
        Task<OrderItemResponseDTO?> GetByIdAsync(int id);
        Task<OrderItemResponseDTO> CreateAsync(CreateOrderItemDTO createOrderItem);
        Task<bool> UpdateAsync(int id, UpdateOrderItemDTO updateOrderItem);
        Task<bool> DeleteAsync(int id);
    }
}
