using Microsoft.AspNetCore.Mvc;
using MenuApiV2.Models;
using MenuApiV2.Repositories;

namespace MenuApiV2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MealController : ControllerBase
    {
        private readonly IMealRepository mealRepository_;

        public MealController(IMealRepository mealRepository)
        {
            mealRepository_ = mealRepository;
        }

        [HttpPut("{id}/{qty}")]
        public async Task<IActionResult> UpdateMealByIdAsync(int id, int qty)
        {
            var meal = await mealRepository_.GetByIdAsync(id);
            if (meal == null)
                return NotFound($"Meal with ID {id} not found.");

            // Kalder repository-metoden
            await mealRepository_.UpdateMealAsync(id, qty);
            await mealRepository_.SaveChangesAsync();

            return Ok(meal);
        }

        // POST /Meal
        [HttpPost]
        public async Task<IActionResult> AddMeal(MealCreateDto dto)
        {
            //Tjekker om model state er valid
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Mapper DTO til Meal-model
            var meal = new Meal
            {
                Name = dto.mealName,
                Qty = dto.qty,
                Price = dto.price,
                TimeStart = dto.timeStart,
                TimeEnd = dto.timeEnd,
                CookId = dto.cookId
            };

            await mealRepository_.AddAsync(meal);
            await mealRepository_.SaveChangesAsync();

            // Returnerer HTTP 201 Created med resource info
            return Ok("Meal successfully created.");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMealByIdAsync(int id)
        {
            var meal = await mealRepository_.GetByIdAsync(id);
            if (meal == null)
            {
                return NotFound($"the providid meal id: {id} was not found"); 
            }

            mealRepository_.Delete(meal);
            await mealRepository_.SaveChangesAsync();

            return NoContent(); 
        }

    }
}
