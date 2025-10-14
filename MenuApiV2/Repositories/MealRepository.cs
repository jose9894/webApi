using MenuApiV2.Models;
using Microsoft.EntityFrameworkCore;
using MenuApiV2.Data;
using MenuApiV2.DTO;

namespace MenuApiV2.Repositories;

public interface IMealRepository : IRepository<Meal>
{
    Task UpdateMealAsync(int mealID, int qty);
    
}

public class MealRepository : Repository<Meal>, IMealRepository
{
    public MealRepository(FoodAppDbContext context) : base(context)
    {

    }

    public async Task UpdateMealAsync(int mealId, int qty)
    {
        var meal = await _dbSet.FindAsync(mealId);
        if (meal != null)
        {
            meal.Qty = qty;
            _dbSet.Update(meal);

        }
    }
    
}