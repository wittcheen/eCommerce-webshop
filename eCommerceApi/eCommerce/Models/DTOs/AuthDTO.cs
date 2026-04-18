namespace eCommerce.Models.DTOs
{
    public class AuthDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class AuthRegisterDTO : AuthDTO
    {
        public string Name { get; set; }
    }

    public class AuthLoginDTO : AuthDTO
    {
    }

    public class AuthResponseDTO
    {
        public string AccessToken { get; set; }
    }
}
