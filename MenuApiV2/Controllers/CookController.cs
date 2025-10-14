using Microsoft.AspNetCore.Mvc;
using MenuApiV2.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using MenuApiV2.Repositories;
using MenuApiV2.DTO;
using System.Threading.Tasks;

namespace MenuApiV2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CookController : ControllerBase
    {
        private readonly ICookRepository cookRepository_;
        public CookController(ICookRepository cookRepository)
        {
            cookRepository_ = cookRepository;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<CookInfoDto>> GetCookInfo(string name)
        {
            var cookInfo = await cookRepository_.GetCookInfoByNameAsync(name);
            if (cookInfo != null)
                return Ok(cookInfo);
            else
                return NotFound($"No cook with name: {name} was found");
        }

        [HttpGet("{name}/meals")]
        public async Task<ActionResult<IEnumerable<MealInfoDto>>> GetAllMealsByName(string name)
        {
            var meals = await cookRepository_.GetAllMealsByNameAsync(name);
            if (meals != null && meals.Any())
                return Ok(meals);
            else
                return NotFound($"No meals for cook: {name} was found");
        }
    }
}

