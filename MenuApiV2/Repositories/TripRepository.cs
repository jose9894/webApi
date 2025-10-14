using MenuApiV2.Models;
using Microsoft.EntityFrameworkCore;
using MenuApiV2.Data;
using MenuApiV2.DTO;

namespace MenuApiV2.Repositories;

public interface ITripRepository : IRepository<Trip>
{
    Task<IEnumerable<TripInfoDto>> GetTripInfoByIdAsync(int id);
}

public class TripRepository : Repository<Trip>, ITripRepository
{
    public TripRepository(FoodAppDbContext context) : base(context)
    {

    }
    public async Task<IEnumerable<TripInfoDto>> GetTripInfoByIdAsync(int id)
    {
            var tripInfo = await _dbSet
            .Where(t => t.TId == id)
            .SelectMany(t => t.TripDetails)
            .OrderBy(td => td.TimeStamp)
            .Select(td => new TripInfoDto
            {
                address = td.Address,
                timeStamp = td.TimeStamp,
                tripType = td.TripType
            })
            .ToListAsync();

            return tripInfo;
        }
    
    }
