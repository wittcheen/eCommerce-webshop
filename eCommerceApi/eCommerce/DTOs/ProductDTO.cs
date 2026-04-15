namespace eCommerce.DTOs
{
    public class ProductDTO
    {
        public int ProductNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryID { get; set; }
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
        public ICollection<ImageResponseDTO>? Images { get; set; }
    }
}
