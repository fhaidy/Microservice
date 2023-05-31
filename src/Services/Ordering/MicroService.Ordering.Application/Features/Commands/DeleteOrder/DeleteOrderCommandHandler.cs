using MediatR;
using MicroService.Ordering.Application.Exceptions;
using MicroService.Ordering.Application.Interfaces.Data;
using MicroService.Ordering.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace MicroService.Ordering.Application.Features.Commands.DeleteOrder;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
{
    private readonly IOrderRepository _repository;
    private readonly ILogger<DeleteOrderCommandHandler> _logger;

    public DeleteOrderCommandHandler(IOrderRepository orderRepository, ILogger<DeleteOrderCommandHandler> logger)
    {
        _repository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var orderToDelete = await _repository.GetByIdAsync(request.Id);
        if (orderToDelete == null)
            throw new NotFoundException(nameof(Order), request.Id);

        await _repository.DeleteAsync(orderToDelete);
        _logger.LogInformation($"Order {orderToDelete.Id} is successfully deleted.");
    }
}