using eCommerce.Data;
using eCommerce.DTOs;
using eCommerce.Interfaces;

namespace eCommerce.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly DatabaseContext _context;

        public OrderItemService(DatabaseContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<OrderItemResponseDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderItemResponseDTO?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderItemResponseDTO> CreateAsync(CreateOrderItemDTO createOrderItem)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, UpdateOrderItemDTO updateOrderItem)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
