namespace eCommerce.Models.DTOs
{
    public class ImageDTO
    {
        public string URL { get; set; }
        public int ProductID { get; set; }
    }

    public class CreateImageDTO : ImageDTO
    {
    }
    
    public class UpdateImageDTO : ImageDTO
    {
    }

    public class ImageResponseDTO : ImageDTO
    {
        public int ID { get; set; }
    }
}
