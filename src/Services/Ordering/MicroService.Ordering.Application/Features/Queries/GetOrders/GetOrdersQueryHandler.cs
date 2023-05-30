using AutoMapper;
using MediatR;
using MicroService.Ordering.Application.Interfaces.Data;

namespace MicroService.Ordering.Application.Features.Queries.GetOrders;

public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IEnumerable<OrderViewModel>>
{
    private readonly IOrderRepository _repository;
    private readonly IMapper _mapper;
    
    public GetOrdersQueryHandler(IOrderRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderViewModel>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _repository.GetOrdersByUserName(request.UserName);
        return _mapper.Map<IEnumerable<OrderViewModel>>(orders);
    }
}