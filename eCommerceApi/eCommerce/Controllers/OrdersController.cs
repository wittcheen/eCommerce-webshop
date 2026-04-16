using eCommerce.Interfaces;
using eCommerce.Models;
using eCommerce.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAll()
        {
            var orders = await _service.GetAllAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponseDTO>> GetById(int id)
        {
            OrderResponseDTO? order = await _service.GetByIdAsync(id);
            if (order == null) return NotFound();

            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<OrderResponseDTO>> Create(CreateOrderDTO order)
        {
            OrderResponseDTO data = await _service.CreateAsync(order);
            return CreatedAtAction(nameof(GetById), new { id = data.OrderID }, data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateOrderDTO order)
        {
            bool result = await _service.UpdateAsync(id, order);
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
