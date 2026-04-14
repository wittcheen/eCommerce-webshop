using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string Email {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
