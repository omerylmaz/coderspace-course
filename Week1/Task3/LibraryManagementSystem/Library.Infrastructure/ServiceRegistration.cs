using Library.Application.Abstractions.Repositories;
using Library.Application.Abstractions.Services;
using Library.Infrastructure.Data;
using Library.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Library.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(o => o.UseSqlite(configuration.GetConnectionString("SqlLiteDb")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddSingleton<ICacheService, CacheService>();

        services.AddSingleton<IConnectionMultiplexer>(sp =>
            ConnectionMultiplexer.Connect(configuration.GetSection("Redis:ConnectionString").Value));


        using var serviceProvider = services.BuildServiceProvider();
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.EnsureCreated();

        return services;
    }
}
