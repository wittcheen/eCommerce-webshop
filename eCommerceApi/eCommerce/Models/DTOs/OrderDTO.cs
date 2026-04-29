namespace eCommerce.Models.DTOs
{
    public class OrderDTO
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public decimal TotalPrice { get; set; }
        public int CustomerID { get; set; }

        public ICollection<OrderItemDTO>? Items { get; set; }
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
        public CustomerDTO Customer { get; set; }
        public new ICollection<OrderItemProductDTO>? Items { get; set; }
    }
}
