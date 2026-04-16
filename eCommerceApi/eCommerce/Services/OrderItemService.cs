using eCommerce.Data;
using eCommerce.Interfaces;
using eCommerce.Models;
using eCommerce.Models.DTOs;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly DatabaseContext _context;

        public OrderItemService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderItemResponseDTO>> GetAllAsync()
        {
            List<OrderItem> orderItems = await _context.OrderItems.ToListAsync();
            return orderItems.Adapt<IEnumerable<OrderItemResponseDTO>>();
        }

        public async Task<OrderItemResponseDTO?> GetByIdAsync(int id)
        {
            OrderItem? orderItem = await _context.OrderItems.FindAsync(id);
            return orderItem.Adapt<OrderItemResponseDTO>();
        }

        public async Task<OrderItemResponseDTO> CreateAsync(CreateOrderItemDTO createOrderItem)
        {
            OrderItem orderItem = createOrderItem.Adapt<OrderItem>();

            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();

            return orderItem.Adapt<OrderItemResponseDTO>();
        }

        public async Task<bool> UpdateAsync(int id, UpdateOrderItemDTO updateOrderItem)
        {
            OrderItem? orderItem = await _context.OrderItems.FindAsync(id);
            if (orderItem == null) return false;

            updateOrderItem.Adapt(orderItem);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            OrderItem? orderItem = await _context.OrderItems.FindAsync(id);
            if (orderItem == null) return false;

            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
