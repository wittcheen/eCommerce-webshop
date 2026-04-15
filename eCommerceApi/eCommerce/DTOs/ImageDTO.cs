namespace eCommerce.DTOs
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
        public int ImageID { get; set; }
    }

    public class ImageResponseDTO : ImageDTO
    {
        public int ImageID { get; set; }
    }
}
