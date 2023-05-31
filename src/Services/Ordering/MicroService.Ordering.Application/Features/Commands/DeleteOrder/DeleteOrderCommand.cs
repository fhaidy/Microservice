using MediatR;

namespace MicroService.Ordering.Application.Features.Commands.DeleteOrder;

public class DeleteOrderCommand : IRequest
{
    public int Id { get; set; }
}