using Microsoft.AspNetCore.Mvc;
using MenuApiV2.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using MenuApiV2.Repositories;
using MenuApiV2.DTO;

namespace MenuApiV2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class  OrderController : ControllerBase
    {
        private readonly IOrderRepository orderRepository_;
        public OrderController(IOrderRepository orderRepository)
        {
            orderRepository_ = orderRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<OrderInfoDto>>> GetOrderInfoByIdAsync(int id)
        {
            var orderInfo = await orderRepository_.GetOrderInfoByIdAsync(id);
            if (orderInfo != null && orderInfo.Any())
            {
                return Ok(orderInfo);
            }
            else
                return NotFound($"The Order id: {id} was not found or had any history");
          
        }
    }
}

