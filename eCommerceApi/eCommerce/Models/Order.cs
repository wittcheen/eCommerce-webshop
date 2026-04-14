using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public decimal TotalPrice { get; set; }

        [ForeignKey("CustomerID")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        public ICollection<OrderItem> Items { get; set; }
    }
}
