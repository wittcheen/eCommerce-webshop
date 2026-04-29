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
            List<Order> orders = await _context.Orders
                .OrderByDescending(o => o.CreatedAt)
                .Include(o => o.Customer)
                .Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                .ToListAsync();
            return orders.Adapt<IEnumerable<OrderResponseDTO>>();
        }

        public async Task<OrderResponseDTO?> GetByIdAsync(int id)
        {
            Order? order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(o => o.OrderID == id);
            return order.Adapt<OrderResponseDTO>();
        }

        public async Task<OrderResponseDTO> CreateAsync(CreateOrderDTO input)
        {
            if (!CustomerExists(input.CustomerID)) return new();

            Order order = input.Adapt<Order>();

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order.Adapt<OrderResponseDTO>();
        }

        public async Task<bool> UpdateAsync(int id, UpdateOrderDTO input)
        {
            if (!CustomerExists(input.CustomerID)) return new();

            Order? order = await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.OrderID == id);
            if (order == null) return false;

            input.Adapt(order);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Order? order = await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.OrderID == id);
            if (order == null) return false;
            
            _context.OrderItems.RemoveRange(order.Items);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool CustomerExists(int id)
        {
            return (_context.Customers?.Any(c => c.CustomerID == id)).GetValueOrDefault();
        }
    }
}
