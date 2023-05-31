using AutoMapper;
using MediatR;
using MicroService.Ordering.Application.Interfaces.Data;
using MicroService.Ordering.Application.Interfaces.Services;
using MicroService.Ordering.Application.Models;
using Microsoft.Extensions.Logging;

namespace MicroService.Ordering.Application.Features.Commands.CheckoutOrder;

public class CheckoutOrderCommandHandler :IRequestHandler<CheckoutOrderCommand, int>
{
    private readonly IOrderRepository _repository;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;
    private readonly ILogger<CheckoutOrderCommandHandler> _logger;

    public CheckoutOrderCommandHandler(IOrderRepository repository, IMapper mapper, IEmailService emailService, ILogger<CheckoutOrderCommandHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _emailService = emailService;
        _logger = logger;
    }

    public async Task<int> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
    {
        var order = _mapper.Map<Domain.Entities.Order>(request.CheckoutOrder);
        var newOrder = await _repository.AddAsync(order);
        _logger.LogInformation($"Order {newOrder.Id} Created.");
        
        await SendEmail(newOrder);
        
        return newOrder.Id;
    }

    private async Task SendEmail(Domain.Entities.Order order)
    {
        var email = new Email { To = "ezozkme@gmail.com", Body = $"Order was created.", Subject = "Order was created" };

        try
        {
            await _emailService.SendEmail(email);
        }
        catch (Exception ex)
        {
            _logger.LogError($"{nameof(Domain.Entities.Order)} {order.Id} failed due to an error with the mail service: {ex.Message}");
        }    
    }
}