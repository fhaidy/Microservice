using MicroService.Ordering.Domain.Common;

namespace MicroService.Ordering.Domain.Entities;

public class Order : EntityBase
{
    public string UserName { get; set; }
    public decimal TotalPrice { get; set; }
    public BillingAddress BillingAddress { get; set; }
    public PaymentInformation PaymentInformation { get; set; }
}