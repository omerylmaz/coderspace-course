using CourseApp.Application.Abstractions.Events;
using CourseApp.Application.Abstractions.Repositories;
using CourseApp.Application.Abstractions.Services;
using CourseApp.Application.Options;
using CourseApp.Domain.Entities;
using CourseApp.Infrastructure.Data;
using CourseApp.Infrastructure.Data.Repositories;
using CourseApp.Infrastructure.Messaging.Consumers;
using CourseApp.Infrastructure.Messaging.Publishers;
using CourseApp.Infrastructure.Options;
using CourseApp.Infrastructure.Services.Auth;
using CourseApp.Infrastructure.Services.Payment;
using Final.Application.Abstractions.Repositories;
using Final.Application.Abstractions.Services;
using Final.Infrastructure.Repositories;
using Final.Infrustructure.Data.Repositories;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace CourseApp.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(o => o.UseSqlServer(configuration.GetConnectionString("Database")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IPaymentService, IyzicoPaymentService>();
        services.AddScoped<IEventPublisher, EventPublisher>();
        services.Configure<IyzicoOptions>(configuration.GetSection("Iyzico"));

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme =
            options.DefaultChallengeScheme =
            options.DefaultForbidScheme =
            options.DefaultScheme =
            options.DefaultSignInScheme =
            options.DefaultSignOutScheme =
            JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            var tokenOptions = configuration.GetSection("TokenOption").Get<TokenOption>();
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = tokenOptions.Issuer,
                ValidateAudience = true,
                ValidAudience = tokenOptions.Audience[0],
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(
            tokenOptions.SecurityKey))
            };
        });

        services.AddIdentityCore<AppUser>(opt =>
        {
            opt.Password.RequireDigit = false;
            opt.Password.RequireLowercase = false;
            opt.Password.RequireUppercase = false;
            opt.Password.RequireNonAlphanumeric = false;
            opt.User.RequireUniqueEmail = true;
        })
        .AddRoles<AppRole>()
        .AddEntityFrameworkStores<AppDbContext>();

        services.AddMassTransit(x =>
        {
            x.AddConsumer<PaymentCompletedEventConsumer>();
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(configuration["RabbitMQ"]);

                cfg.ConfigureEndpoints(context);
            });
        });

        return services;
    }

    public static async Task<WebApplication> UseInfrastructureServices(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            //await RoleSeeder.SeedRoles(roleManager);
            //await UserSeeder.SeedUsers(userManager);
        }
        return app;
    }
}
