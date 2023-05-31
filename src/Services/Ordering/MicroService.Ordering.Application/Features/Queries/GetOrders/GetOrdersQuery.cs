using MediatR;
using MicroService.Ordering.Application.Models;

namespace MicroService.Ordering.Application.Features.Queries.GetOrders;

public class GetOrdersQuery : IRequest<IEnumerable<Order>>
{
    public string UserName { get; set; }

    public GetOrdersQuery(string userName)
    {
        UserName = userName;
    }
}