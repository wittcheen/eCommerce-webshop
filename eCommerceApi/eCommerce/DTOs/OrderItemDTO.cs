namespace eCommerce.DTOs
{
    public class OrderItemDTO
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class CreateOrderItemDTO : OrderItemDTO
    {
    }

    public class UpdateOrderItemDTO : OrderItemDTO
    {
        public int OrderItemID { get; set; }
    }

    public class OrderItemResponseDTO : OrderItemDTO
    {
        public int OrderItemID { get; set; }
    }
}
