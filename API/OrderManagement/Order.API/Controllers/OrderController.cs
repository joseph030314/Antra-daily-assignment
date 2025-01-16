using Microsoft.AspNetCore.Mvc;
using Order.ApplicationCore.Interfaces;
using Order.ApplicationCore.Entities;

namespace Order.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController(IOrderService orderService) : ControllerBase
    {
        private readonly IOrderService _orderService = orderService;

        [HttpGet]
        public async Task<IActionResult> GetAllOrders() => Ok(await _orderService.GetAllOrdersAsync());

        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetOrderByCustomerId(int customerId) => Ok(await _orderService.GetOrderByCustomerIdAsync(customerId));

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] Order.ApplicationCore.Entities.Order order)
        {
            await _orderService.AddOrderAsync(order);
            return CreatedAtAction(nameof(GetOrderByCustomerId), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] Order.ApplicationCore.Entities.Order order)
        {
            if (id != order.Id) return BadRequest();
            await _orderService.UpdateOrderAsync(order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderService.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}
