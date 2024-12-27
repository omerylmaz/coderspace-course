using CourseApp.Domain.Entities;
using CourseApp.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Infrastructure.Data.SeedData;

internal static class RoleSeeder
{
    public static async Task SeedRoles(RoleManager<AppRole> roleManager)
    {
        var roles = Enum.GetNames(typeof(UserRoles));

        foreach (var role in roles)
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new AppRole { Id = Guid.NewGuid() ,Name = role });
    }
}