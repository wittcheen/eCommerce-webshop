using eCommerce.Interfaces;
using eCommerce.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _service;

        public ImagesController(IImageService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageResponseDTO>>> GetAll()
        {
            var images = await _service.GetAllAsync();
            return Ok(images);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ImageResponseDTO>> GetById(int id)
        {
            ImageResponseDTO? image = await _service.GetByIdAsync(id);
            if (image == null) return NotFound();

            return Ok(image);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ImageResponseDTO>> Create(CreateImageDTO image)
        {
            ImageResponseDTO data = await _service.CreateAsync(image);
            return CreatedAtAction(nameof(GetById), new { id = data.ImageID }, data);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateImageDTO image)
        {
            bool result = await _service.UpdateAsync(id, image);
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
