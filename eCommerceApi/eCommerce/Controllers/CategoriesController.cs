using eCommerce.Interfaces;
using eCommerce.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryResponseDTO>>> GetAll()
        {
            var categories = await _service.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResponseDTO>> GetById(int id)
        {
            CategoryResponseDTO? category = await _service.GetByIdAsync(id);
            if (category == null) return NotFound();

            return Ok(category);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<CategoryResponseDTO>> Create(CreateCategoryDTO category)
        {
            CategoryResponseDTO data = await _service.CreateAsync(category);
            return CreatedAtAction(nameof(GetById), new { id = data.CategoryID }, data);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCategoryDTO category)
        {
            bool result = await _service.UpdateAsync(id, category);
            if (result == false) return NotFound();

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _service.DeleteAsync(id);
            if (result == false) return NotFound();

            return NoContent();
        }
    }
}
