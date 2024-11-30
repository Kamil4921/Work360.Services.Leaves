using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Work360.Services.Leaves.Application.Services;
using Work360.Services.Leaves.Core.Repositories;
using Work360.Services.Leaves.Infrastructure.Postgres;
using Work360.Services.Leaves.Infrastructure.Services;

namespace Work360.Services.Leaves.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IEventMapper, EventMapper>();
        services.AddTransient<ICustomerRepository, EmployeeRepository>();
        services.AddTransient<ILeaveRepository, LeaveRepository>();
        services.AddTransient<IMessageBroker, MessageBroker>();
        services.AddSingleton<ServiceBusMessageReceiver>();
        
        services.AddEntityFrameworkNpgsql().AddDbContext<AppDbContext>(opt =>
            opt.UseNpgsql("Server=localhost;Port=5433;Database=postgres;User ID=postgres;Password=password;"));

        return services;
    }
}