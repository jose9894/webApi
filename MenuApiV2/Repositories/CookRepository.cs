using MenuApiV2.Models;
using Microsoft.EntityFrameworkCore;
using MenuApiV2.Data;
using MenuApiV2.DTO;

namespace MenuApiV2.Repositories;

public interface ICookRepository : IRepository<Cook>
{

    Task<CookInfoDto> GetCookInfoByNameAsync(string name);
    Task<IEnumerable<MealInfoDto>> GetAllMealsByNameAsync(string name);

}

public class CookRepository : Repository<Cook>, ICookRepository
{
    public CookRepository(FoodAppDbContext context) : base(context)
    {

    }

    public async Task<CookInfoDto> GetCookInfoByNameAsync(string name)
    {
        var Cook = await _dbSet.FirstOrDefaultAsync(c => c.Name == name);
        if (Cook != null)
        {
            return new CookInfoDto
            {
                cookName = Cook.Name,
                phoneNr = Cook.PhoneNr,
                address = Cook.Address,
                Certificate = Cook.Certificate,

            };
        }

        return null;
    }

    public async Task<IEnumerable<MealInfoDto>> GetAllMealsByNameAsync(string name)
    {
        var mealInfo = await _dbSet.Where(c => c.Name == name).SelectMany(c => c.Meals)
        .Select(MI => new MealInfoDto
        {
            mealName = MI.Name,
            qty = MI.Qty,
            price = MI.Price,
            timeStart = MI.TimeStart,
            timeEnd = MI.TimeEnd


        }).ToListAsync();

        return mealInfo;
    }

}