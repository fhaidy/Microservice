using AutoMapper;
using MicroService.Ordering.Application.Features.Queries.GetOrders;
using MicroService.Ordering.Application.Models;
using MicroService.Ordering.Domain.Entities;
using Order = MicroService.Ordering.Application.Models.Order;

namespace MicroService.Ordering.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Domain.Entities.Order, Order>().ReverseMap();
        CreateMap<Domain.Entities.Order, CheckoutOrder>().ReverseMap();
    }
}