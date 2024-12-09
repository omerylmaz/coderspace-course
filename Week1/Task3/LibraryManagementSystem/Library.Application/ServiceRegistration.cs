using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Library.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(conf =>
        {
            conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddAutoMapper(typeof(MapperProfile));
        return services;
    }
}
