using eCommerce.Models.DTOs;

namespace eCommerce.Interfaces
{
    public interface IOrderItemService : IGeneric<OrderItemResponseDTO, CreateOrderItemDTO, UpdateOrderItemDTO>
    {

    }
}
