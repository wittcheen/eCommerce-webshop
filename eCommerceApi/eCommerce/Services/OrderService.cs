using eCommerce.Data;
using eCommerce.Interfaces;
using eCommerce.Models;
using eCommerce.Models.DTOs;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Services
{
    public class OrderService : IOrderService
    {
        private readonly DatabaseContext _context;

        public OrderService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderResponseDTO>> GetAllAsync()
        {
            List<Order> orders = await _context.Orders.ToListAsync();
            return orders.Adapt<IEnumerable<OrderResponseDTO>>();
        }

        public async Task<OrderResponseDTO?> GetByIdAsync(int id)
        {
            Order? order = await _context.Orders.FindAsync(id);
            return order.Adapt<OrderResponseDTO>();
        }

        public async Task<OrderResponseDTO> CreateAsync(CreateOrderDTO createOrder)
        {
            Order order = createOrder.Adapt<Order>();

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order.Adapt<OrderResponseDTO>();
        }

        public async Task<bool> UpdateAsync(int id, UpdateOrderDTO updateOrder)
        {
            Order? order = await _context.Orders.FindAsync(id);
            if (order == null) return false;

            updateOrder.Adapt(order);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Order? order = await _context.Orders.FindAsync(id);
            if (order == null) return false;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
