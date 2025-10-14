using Microsoft.AspNetCore.Mvc;
using MenuApiV2.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using MenuApiV2.Repositories;
using MenuApiV2.DTO;


namespace MenuApiV2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class  TripController : ControllerBase
    {
        private readonly ITripRepository tripRepository_;

        public TripController(ITripRepository tripRepository)
        {
         tripRepository_ = tripRepository;
        }

        // GET /Cook
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TripInfoDto>>> GetTripInfoByIdAsync(int id)
        {
            var tripInfo = await tripRepository_.GetTripInfoByIdAsync(id);
            if (tripInfo != null && tripInfo.Any())
            {
                return Ok(tripInfo);
            }
            else
                return NotFound($"The id: {id} was not found or had any trips");
        }
    }
}

