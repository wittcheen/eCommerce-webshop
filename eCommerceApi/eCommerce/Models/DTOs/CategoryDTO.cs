namespace eCommerce.Models.DTOs
{
    public class CategoryDTO
    {
        public string Name { get; set; }
    }

    public class CreateCategoryDTO : CategoryDTO
    {
    }

    public class UpdateCategoryDTO : CategoryDTO
    {
    }

    public class CategoryResponseDTO : CategoryDTO
    {
        public int ID { get; set; }
    }
}
