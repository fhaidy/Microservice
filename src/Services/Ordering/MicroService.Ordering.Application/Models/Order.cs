using MicroService.Ordering.Domain.Entities;

namespace MicroService.Ordering.Application.Models;

public class Order
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public decimal TotalPrice { get; set; }
    public BillingAddress BillingAddress { get; set; }
    public PaymentInformation PaymentInformation { get; set; }
}