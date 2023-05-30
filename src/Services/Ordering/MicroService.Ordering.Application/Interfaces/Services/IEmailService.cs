using MicroService.Ordering.Application.Models;

namespace MicroService.Ordering.Application.Interfaces.Services;

public interface IEmailService
{
    Task<bool> SendEmail(Email email);
}