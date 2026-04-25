namespace eCommerce.Models.DTOs
{
    public class OrderDTO
    {
        public DateTime CreatedAt { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomerID { get; set; }
    }

    public class CreateOrderDTO : OrderDTO
    {
    }

    public class UpdateOrderDTO : OrderDTO
    {
    }

    public class OrderResponseDTO : OrderDTO
    {
        public int ID { get; set; }
        public ICollection<OrderItemResponseDTO>? Items { get; set; }
    }
}
