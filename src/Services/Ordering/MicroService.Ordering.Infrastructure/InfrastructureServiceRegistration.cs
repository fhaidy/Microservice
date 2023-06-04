using MicroService.Ordering.Application.Interfaces.Data;
using MicroService.Ordering.Application.Interfaces.Services;
using MicroService.Ordering.Application.Models;
using MicroService.Ordering.Infrastructure.Data;
using MicroService.Ordering.Infrastructure.Mail;
using MicroService.Ordering.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroService.Ordering.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<OrderContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("OrderingConnectionString"),
                opts => opts.EnableRetryOnFailure(4)));

        services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
        services.AddScoped<IOrderRepository, OrderRepository>();

        services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
        services.AddTransient<IEmailService, EmailService>();
    }
}