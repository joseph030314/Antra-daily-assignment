using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.ApplicationCore.Contracts.IServices;
using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Models.Request;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServiceAsync orderService;

        public OrderController(IOrderServiceAsync orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await orderService.GetAllOrders();
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrder([FromBody] OrderRequestModel orderRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await orderService.InsertOrder(orderRequest);
            return Ok(result);
        }

        [HttpGet]
        [Route("customer/{customerId}")]
        public async Task<IActionResult> GetAOrderByCustomerId(int customerId)
        {
            var orders = await orderService.GetOrdersByCustomerId(customerId);
            return Ok(orders);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await orderService.DeleteOrder(id);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateOrder([FromBody]OrderRequestModel orderRequest, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await orderService.UpdateOrder(orderRequest, id);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
    }
}
