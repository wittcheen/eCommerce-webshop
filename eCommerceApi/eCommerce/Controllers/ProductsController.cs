using eCommerce.Interfaces;
using eCommerce.Models;
using eCommerce.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponseDTO>>> GetAll()
        {
            var products = await _service.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponseDTO>> GetById(int id)
        {
            ProductResponseDTO? product = await _service.GetByIdAsync(id);
            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductResponseDTO>> Create(CreateProductDTO product)
        {
            ProductResponseDTO data = await _service.CreateAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = data.ProductID }, data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductDTO product)
        {
            bool result = await _service.UpdateAsync(id, product);
            if (result == false) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _service.DeleteAsync(id);
            if (result == false) return NotFound();

            return NoContent();
        }
    }
}
