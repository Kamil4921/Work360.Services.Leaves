using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Work360.Services.Leaves.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
        });
        
        return services;
    }
}
