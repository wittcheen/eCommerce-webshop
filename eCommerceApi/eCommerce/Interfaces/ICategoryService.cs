using eCommerce.Models.DTOs;

namespace eCommerce.Interfaces
{
    public interface ICategoryService : IGeneric<CategoryResponseDTO, CreateCategoryDTO, UpdateCategoryDTO>
    {

    }
}
