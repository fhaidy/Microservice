using System.Net;
using MediatR;
using MicroService.Ordering.Application.Features.Commands.CheckoutOrder;
using MicroService.Ordering.Application.Features.Commands.DeleteOrder;
using MicroService.Ordering.Application.Features.Commands.UpdateOrder;
using MicroService.Ordering.Application.Features.Queries.GetOrders;
using MicroService.Ordering.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroService.Ordering.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet("{userName}", Name = "GetOrder")]
    [ProducesResponseType(typeof(IEnumerable<Order>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByUserName(string userName)
    {
        var query = new GetOrdersQuery(userName);
        var orders = await _mediator.Send(query);
        return Ok(orders);
    }

    // testing purpose
    [HttpPost(Name = "CheckoutOrder")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> CheckoutOrder([FromBody] CheckoutOrderCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut(Name = "UpdateOrder")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteOrder")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteOrder(int id)
    {
        var command = new DeleteOrderCommand() { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}