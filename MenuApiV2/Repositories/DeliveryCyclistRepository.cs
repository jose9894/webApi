using MenuApiV2.Models;
using Microsoft.EntityFrameworkCore;
using MenuApiV2.Data;
using MenuApiV2.DTO;

namespace MenuApiV2.Repositories;

public interface IDeliveryCyclistRepository : IRepository<DeliveryCyclist>
{
    Task<IEnumerable<RevenueInfoDto>> GetRevenueInfoByIdAsync(int id);
}

public class DeliveryCyclistRepository : Repository<DeliveryCyclist>, IDeliveryCyclistRepository
{
    public DeliveryCyclistRepository(FoodAppDbContext context) : base(context)
    {

    }

    public async Task<IEnumerable<RevenueInfoDto>> GetRevenueInfoByIdAsync(int id)
    {
        var cyclist = await _dbSet.FindAsync(id);
        if (cyclist != null)
        {
            var revInfo = await _dbSet
         .Where(dc => dc.DcId == id)
         .SelectMany(dc => dc.Trips)
         .GroupBy(t => t.OIdNavigation.ODate.Month)
         .OrderBy(g => g.Key)
         .Select(g => new RevenueInfoDto
         {
             month = new DateTime(1, g.Key, 1).ToString("MMMM"),
             time = g.Sum(t => t.TTime) / 60.0,
             pay = g.Sum(p => p.TripPay)
         })
         .ToListAsync();

            return revInfo;
        }
        return null;
    }
    
}