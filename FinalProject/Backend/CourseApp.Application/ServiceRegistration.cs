using FluentValidation;
using Final.Application.Abstractions.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Final.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MapperProfile));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        //services.AddFluentValidation();
        //services.AddScoped<IBookService, BookService>();
        services.AddMediatR(conf =>
        {
            conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        //services.AddScoped<IUserService, UserService>();
        //services.AddScoped<IRoleService, RoleService>();

        return services;
    }
}
