using MenuApiV2.Models;
using Microsoft.EntityFrameworkCore;
using MenuApiV2.Data;
using MenuApiV2.DTO;

namespace MenuApiV2.Repositories;

public interface IRatingRepository : IRepository<Rating>
{
    Task<RatingInfoDto> GetAverageRatingByCookNameAsync(string name);
}

public class RatingRepository : Repository<Rating>, IRatingRepository
{
    public RatingRepository(FoodAppDbContext context) : base(context)
    {

    }
    public async Task<RatingInfoDto> GetAverageRatingByCookNameAsync(string name)
    {
            var avgStars = await _dbSet
              .Where(r => r.Cook.Name == name)
              .Select(r => (double?)r.CStars)
              .AverageAsync();

            return new RatingInfoDto
            {
                Name = name,
                Rating = avgStars ?? 0
            };
    }

}