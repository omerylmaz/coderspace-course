using CourseApp.Domain.Entities;
using CourseApp.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace CourseApp.Infrastructure.Data.SeedData;

internal static class UserSeeder
{
    public static async Task SeedUsers(UserManager<AppUser> userManager)
    {
        var users = new List<AppUser>
        {
            new AppUser { Id = Guid.NewGuid(), UserName = "user1", Email = "user1@example.com", FullName = "Ali Yılmaz" },
            new AppUser { Id = Guid.NewGuid(), UserName = "user2", Email = "user2@example.com", FullName = "Ahmet Kaya" },
            new AppUser { Id = Guid.NewGuid(), UserName = "user3", Email = "user3@example.com", FullName = "Ayşe Demir" },
            new AppUser { Id = Guid.NewGuid(), UserName = "user4", Email = "user4@example.com", FullName = "Fatma Çelik" },
            new AppUser { Id = Guid.NewGuid(), UserName = "user5", Email = "user5@example.com", FullName = "Mehmet Şahin" },
        };

        var teachers = new List<AppUser>
        {
            new AppUser { Id = Guid.NewGuid(), UserName = "teacher1", Email = "teacher1@example.com", FullName = "Emre Güneş" },
            new AppUser { Id = Guid.NewGuid(), UserName = "teacher2", Email = "teacher2@example.com", FullName = "Zeynep Kara" },
            new AppUser { Id = Guid.NewGuid(), UserName = "teacher3", Email = "teacher3@example.com", FullName = "Hüseyin Ak" },
        };

        foreach (var user in users)
        {
            if (await userManager.FindByEmailAsync(user.Email) == null)
            {
                var result = await userManager.CreateAsync(user, "user123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, UserRoles.User.ToString());
                }
            }
        }

        foreach (var teacher in teachers)
        {
            if (await userManager.FindByEmailAsync(teacher.Email) == null)
            {
                var result = await userManager.CreateAsync(teacher, "teacher123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(teacher, UserRoles.Teacher.ToString());
                }
            }
        }
    }
}
