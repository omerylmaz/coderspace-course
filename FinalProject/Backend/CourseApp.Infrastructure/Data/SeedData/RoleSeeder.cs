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
    public static List<AppRole> SeedRoles()
    {
        var roles = Enum.GetNames(typeof(UserRoles));

        var appRoles = new List<AppRole>() 
        {
            new AppRole{Id = Guid.Parse("41330934-5681-4660-bfd0-a7c91940073f"), Name = UserRoles.User.ToString(), NormalizedName = UserRoles.User.ToString().ToUpper()},
            new AppRole{Id = Guid.Parse("8672057e-cd8e-4f23-b002-f1a2785fe8f3"), Name = UserRoles.Teacher.ToString(), NormalizedName = UserRoles.Teacher.ToString().ToUpper()}
        };

        return appRoles;
    }
}