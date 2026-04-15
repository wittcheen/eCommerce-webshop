namespace eCommerce.DTOs
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
        public int OrderID { get; set; }
    }

    public class OrderResponseDTO : OrderDTO
    {
        public int OrderID { get; set; }
        public ICollection<OrderItemResponseDTO>? Items { get; set; }
    }
}
