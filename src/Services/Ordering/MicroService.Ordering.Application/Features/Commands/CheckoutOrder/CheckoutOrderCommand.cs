using MediatR;

namespace MicroService.Ordering.Application.Features.Commands.CheckoutOrder;

public class CheckoutOrderCommand : IRequest<int>
{
    public Models.CheckoutOrder CheckoutOrder { get; set; }
}