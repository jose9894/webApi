using Microsoft.AspNetCore.Mvc;
using MenuApiV2.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using MenuApiV2.Repositories;

namespace MenuApiV2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryCyclistController : ControllerBase
    {
        private readonly IDeliveryCyclistRepository DeliveryCyclistRepository_;

        public DeliveryCyclistController(IDeliveryCyclistRepository DeliveryCyclistRepository)
        {
            DeliveryCyclistRepository_ = DeliveryCyclistRepository;
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<IEnumerable<DeliveryCyclist>>> GetRevenueInfoByIdAsync(int id)
        {
            var revenue = await DeliveryCyclistRepository_.GetRevenueInfoByIdAsync(id);

            if (revenue != null)
            {
                return Ok(revenue);
            }
            else
                return NotFound($"The Delivery id: {id} was not found or had any history");
        }
    }
}


