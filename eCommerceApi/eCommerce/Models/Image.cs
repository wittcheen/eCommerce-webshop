using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Models
{
    public class Image
    {
        [Key]
        public int ImageID { get; set; }
        public string URL { get; set; }

        [ForeignKey("ProductID")]
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
