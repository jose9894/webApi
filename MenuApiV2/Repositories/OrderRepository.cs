using MenuApiV2.Models;
using Microsoft.EntityFrameworkCore;
using MenuApiV2.Data;
using MenuApiV2.DTO;

namespace MenuApiV2.Repositories;

public interface IOrderRepository : IRepository<Order>
{
    Task<IEnumerable<OrderInfoDto>> GetOrderInfoByIdAsync(int id);

}

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(FoodAppDbContext context) : base(context)
    {

    }
    public async Task<IEnumerable<OrderInfoDto>> GetOrderInfoByIdAsync(int id)
    {

        var orderInfo = await _dbSet.Where(o => o.CId == id).SelectMany(o => o.OrderDetails)
        .Select(OI => new OrderInfoDto
        {
            mealName = OI.MIdNavigation.Name,
            cookName = OI.MIdNavigation.Cook.Name,
            quantity = OI.Qty

        }).ToListAsync();

        return orderInfo;

    }

}
