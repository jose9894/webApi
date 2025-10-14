using Microsoft.AspNetCore.Mvc;
using MenuApiV2.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using MenuApiV2.Repositories;

namespace MenuApiV2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class  CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository_;
        public CustomerController(ICustomerRepository customerRepository)
        {
            customerRepository_ = customerRepository;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomerOrderHistory(int id)
        {
            var history = await customerRepository_.GetCustomerOrderHistoryInfoByIdAsync(id);

            if (history != null && history.Any())
            {
                return Ok(history);
            }
            else
                return NotFound($"The costumer id: {id} was not found or had any history");
        }
    }
}



