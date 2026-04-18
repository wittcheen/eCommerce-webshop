using eCommerce.Interfaces;
using eCommerce.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemService _service;

        public OrderItemsController(IOrderItemService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItemResponseDTO>>> GetAll()
        {
            var orderItems = await _service.GetAllAsync();
            return Ok(orderItems);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItemResponseDTO>> GetById(int id)
        {
            OrderItemResponseDTO? orderItem = await _service.GetByIdAsync(id);
            if (orderItem == null) return NotFound();

            return Ok(orderItem);
        }

        [HttpPost]
        public async Task<ActionResult<OrderItemResponseDTO>> Create(CreateOrderItemDTO orderItem)
        {
            OrderItemResponseDTO data = await _service.CreateAsync(orderItem);
            return CreatedAtAction(nameof(GetById), new { id = data.OrderItemID }, data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateOrderItemDTO orderItem)
        {
            bool result = await _service.UpdateAsync(id, orderItem);
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
