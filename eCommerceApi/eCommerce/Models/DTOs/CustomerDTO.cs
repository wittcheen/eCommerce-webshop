namespace eCommerce.Models.DTOs
{
    public class CustomerDTO
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }

    public class CreateCustomerDTO : CustomerDTO
    {
    }

    public class UpdateCustomerDTO : CustomerDTO
    {
    }

    public class CustomerResponseDTO : CustomerDTO
    {
        public int ID { get; set; }
    }
}
