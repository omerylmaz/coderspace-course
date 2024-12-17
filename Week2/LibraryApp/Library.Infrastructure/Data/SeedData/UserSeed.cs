using Library.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Data.SeedData;

public static class UserSeed
{
    public static async Task SeedUserData(this IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

        const string adminRoleName = "admin";
        if (!await roleManager.RoleExistsAsync(adminRoleName))
        {
            var roleResult = await roleManager.CreateAsync(new AppRole() {Id = Guid.NewGuid() ,Name = adminRoleName });
        }

        const string adminEmail = "admin@gmail.com";
        const string adminPassword = "admin123";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            var newAdminUser = new AppUser
            {
                Id = Guid.NewGuid(),
                UserName = "admin",
                Email = adminEmail,
                EmailConfirmed = true
            };

            var userResult = await userManager.CreateAsync(newAdminUser, adminPassword);

            await userManager.AddToRoleAsync(newAdminUser, adminRoleName);
        }
    }


}
