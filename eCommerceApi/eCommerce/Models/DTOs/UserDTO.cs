namespace eCommerce.Models.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class CreateUserDTO : UserDTO
    {
    }

    public class UpdateUserDTO : UserDTO
    {
        public int UserID { get; set; }
    }

    public class UserResponseDTO : UserDTO
    {
        public int UserID { get; set; }
    }
}
