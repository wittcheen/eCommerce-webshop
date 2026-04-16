using eCommerce.Models.DTOs;

namespace eCommerce.Interfaces
{
    public interface IOrderService : IGeneric<OrderResponseDTO, CreateOrderDTO, UpdateOrderDTO>
    {

    }
}
