using MediatR;
using MicroService.Ordering.Application.Models;

namespace MicroService.Ordering.Application.Features.Commands.UpdateOrder;

public class UpdateOrderCommand : IRequest
{
    public Order Order { get; set; }
}