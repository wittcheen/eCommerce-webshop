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
        public int CategoryID { get; set; }
    }

    public class CategoryResponseDTO : CategoryDTO
    {
        public int CategoryID { get; set; }
        public ICollection<ProductResponseDTO>? Products { get; set; }
    }
}
