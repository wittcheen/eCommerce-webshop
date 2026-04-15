using eCommerce.Data;
using eCommerce.DTOs;
using eCommerce.Interfaces;

namespace eCommerce.Services
{
    public class OrderService : IOrderService
    {
        private readonly DatabaseContext _context;

        public OrderService(DatabaseContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<OrderResponseDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderResponseDTO?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderResponseDTO> CreateAsync(CreateOrderDTO createOrder)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, UpdateOrderDTO updateOrder)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
