using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public int ProductNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("CategoryID")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
