using AutoMapper;
using MicroService.Ordering.Application.Features.Queries.GetOrders;
using MicroService.Ordering.Domain.Entities;

namespace MicroService.Ordering.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Order, OrderViewModel>().ReverseMap();
        // CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
        // CreateMap<Order, UpdateOrderCommand>().ReverseMap();
    }
}