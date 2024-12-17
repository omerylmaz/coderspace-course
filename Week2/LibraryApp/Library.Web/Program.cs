using Library.Application;
using Library.Domain.Entities;
using Library.Infrastructure;
using Library.Infrastructure.Data;
using Library.Web;
using Library.Infrastructure.Data.SeedData;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration);


builder.Services.ConfigureApplicationCookie(opt =>
{
    var cookieBuilder = new CookieBuilder();

    cookieBuilder.Name = "LibraryCookie";
    opt.LoginPath = new PathString("/User/Signin");
    opt.LogoutPath = new PathString("/User/logout");
    opt.AccessDeniedPath = new PathString("/Role/AccessDenied");
    opt.Cookie = cookieBuilder;
    opt.ExpireTimeSpan = TimeSpan.FromDays(60);
    opt.SlidingExpiration = true;
});

builder.Services.AddAuthentication("LibraryCookie")
    .AddCookie("LibraryCookie", options =>
    {
        options.LoginPath = "/user/signin";
        options.LogoutPath = "/user/signout";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    });

builder.Services.AddAuthorization();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    await serviceProvider.SeedUserData();
}


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();



app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
