using MicroService.Ordering.Domain.Entities;

namespace MicroService.Ordering.Application.Interfaces.Data;

public interface IOrderRepository : IAsyncRepository<Order>
{
    Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
}