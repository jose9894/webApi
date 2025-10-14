using Microsoft.AspNetCore.Mvc;
using MenuApiV2.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using MenuApiV2.Repositories;

namespace MenuApiV2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly IRatingRepository ratingRepository_;
        public RatingController(IRatingRepository ratingRepository)
        {
            ratingRepository_ = ratingRepository;
        }

        // GET /Cook
        [HttpGet("{name}")]
        public async Task<ActionResult<Order>> GetAverageRatingByCookNameAsync(string name)
        {
            var avgRating = await ratingRepository_.GetAverageRatingByCookNameAsync(name);
            if (avgRating != null && avgRating.Rating > 0)
            {
                return Ok(avgRating);
            }
            else
                return NotFound($"The name: {name} was not found or had any ratings");
        }
    }
}

