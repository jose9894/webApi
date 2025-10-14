using MenuApiV2.Models;
using Microsoft.EntityFrameworkCore;
using MenuApiV2.Data;
using MenuApiV2.DTO;

namespace MenuApiV2.Repositories;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<IEnumerable<CustomerOrderHistoryInfoDto>> GetCustomerOrderHistoryInfoByIdAsync(int id);
}

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(FoodAppDbContext context) : base(context)
    {

    }

    public async Task<IEnumerable<CustomerOrderHistoryInfoDto>> GetCustomerOrderHistoryInfoByIdAsync(int id)
    {
       
            var customerOrdHist = await _dbSet.Where(c => c.CId == id)
            .SelectMany(c => c.Orders)
            .SelectMany(o => o.OrderDetails)
            .Select(CH => new CustomerOrderHistoryInfoDto
            {
                date = CH.OIdNavigation.ODate,
                mealName = CH.MIdNavigation.Name,
                qty = CH.Qty,
                unitprice = CH.MIdNavigation.Price,
                totalPrice = CH.Qty * CH.MIdNavigation.Price,
                address = CH.OIdNavigation.CIdNavigation.Address
            }).ToListAsync();

            return customerOrdHist;
    }
}
