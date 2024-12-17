using Library.Application.Abstractions.Services;
using Library.Application.Services;
using Library.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MapperProfile));
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRoleService, RoleService>();

        return services;
    }
}
