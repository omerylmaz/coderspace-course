using FluentValidation;
using Final.Application.Abstractions.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using CourseApp.Application;

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

            conf.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        //services.AddScoped<IUserService, UserService>();
        //services.AddScoped<IRoleService, RoleService>();

        return services;
    }
}
