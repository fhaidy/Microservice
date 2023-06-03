using MicroService.Ordering.Application.Interfaces.Data;
using MicroService.Ordering.Domain.Entities;
using MicroService.Ordering.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MicroService.Ordering.Infrastructure.Repositories;

public class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(OrderContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
    {
        var orderList = await _dbContext.Orders
            .Where(o => o.UserName == userName)
            .ToListAsync();
        return orderList;
    }
}