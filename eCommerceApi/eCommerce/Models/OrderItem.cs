using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("OrderID")]
        public int OrderID { get; set; }
        public Order Order { get; set; }

        [ForeignKey("ProductID")]
        public int ProductID { get; set; }
        public Product Product { get; set; }

    }
}
