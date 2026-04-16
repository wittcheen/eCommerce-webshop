using eCommerce.Models.DTOs;

namespace eCommerce.Interfaces
{
    public interface IProductService : IGeneric<ProductResponseDTO, CreateProductDTO, UpdateProductDTO>
    {

    }
}
