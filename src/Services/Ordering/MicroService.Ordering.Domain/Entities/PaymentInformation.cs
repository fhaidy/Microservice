namespace MicroService.Ordering.Domain.Entities;

public class PaymentInformation
{
    public string CardName { get; set; }
    public string CardNumber { get; set; }
    public string Expiration { get; set; }
    public string CVV { get; set; }
    public int PaymentMethod { get; set; }
}