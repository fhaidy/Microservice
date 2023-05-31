using AutoMapper;
using MediatR;
using MicroService.Ordering.Application.Exceptions;
using MicroService.Ordering.Application.Features.Commands.CheckoutOrder;
using MicroService.Ordering.Application.Interfaces.Data;
using MicroService.Ordering.Application.Models;
using Microsoft.Extensions.Logging;

namespace MicroService.Ordering.Application.Features.Commands.UpdateOrder;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
{
    private readonly IOrderRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<CheckoutOrderCommandHandler> _logger;

    public UpdateOrderCommandHandler(IOrderRepository repository, IMapper mapper, ILogger<CheckoutOrderCommandHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetByIdAsync(request.Order.Id);
        if (order == null)
            throw new NotFoundException(nameof(Domain.Entities.Order), request.Order.Id);

        _mapper.Map(request.Order, order, typeof(Order), typeof(Domain.Entities.Order));

        await _repository.UpdateAsync(order);
    }
}