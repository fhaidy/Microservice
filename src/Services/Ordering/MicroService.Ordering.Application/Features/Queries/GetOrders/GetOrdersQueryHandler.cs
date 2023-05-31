using AutoMapper;
using MediatR;
using MicroService.Ordering.Application.Interfaces.Data;
using MicroService.Ordering.Application.Models;

namespace MicroService.Ordering.Application.Features.Queries.GetOrders;

public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IEnumerable<Order>>
{
    private readonly IOrderRepository _repository;
    private readonly IMapper _mapper;
    
    public GetOrdersQueryHandler(IOrderRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _repository.GetOrdersByUserName(request.UserName);
        return _mapper.Map<IEnumerable<Order>>(orders);
    }
}