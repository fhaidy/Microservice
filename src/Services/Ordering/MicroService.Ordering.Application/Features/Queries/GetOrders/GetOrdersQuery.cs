using MediatR;

namespace MicroService.Ordering.Application.Features.Queries.GetOrders;

public class GetOrdersQuery : IRequest<IEnumerable<OrderViewModel>>
{
    public string UserName { get; set; }

    public GetOrdersQuery(string userName)
    {
        UserName = userName;
    }
}