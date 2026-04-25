namespace eCommerce.Models.DTOs
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryID { get; set; }

        public ICollection<ImageDTO>? Images { get; set; }
    }

    public class CreateProductDTO : ProductDTO
    {
    }

    public class UpdateProductDTO : ProductDTO
    {
        public int ProductID { get; set; }
    }

    public class ProductResponseDTO : ProductDTO
    {
        public int ProductID { get; set; }
        public int ProductNumber { get; set; }
    }
}
