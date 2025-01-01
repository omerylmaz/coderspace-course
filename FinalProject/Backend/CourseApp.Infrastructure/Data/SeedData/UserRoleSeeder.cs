using CourseApp.Domain.Entities;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace CourseApp.Infrastructure.Data.SeedData;

internal static class UserRoleSeeder
{
    public static List<IdentityUserRole<Guid>> SeedUserRoles()
    {
        return new List<IdentityUserRole<Guid>>
        {
            // Users and their roles
            new IdentityUserRole<Guid>
            {
                UserId = Guid.Parse("9beb751f-f3b8-4e45-a938-622ebc1dd038"), 
                RoleId = Guid.Parse("41330934-5681-4660-bfd0-a7c91940073f")  
            },
            new IdentityUserRole<Guid>
            {
                UserId = Guid.Parse("54039b1c-f914-4171-97a8-f78a9c107935"), 
                RoleId = Guid.Parse("41330934-5681-4660-bfd0-a7c91940073f")  
            },
            new IdentityUserRole<Guid>
            {
                UserId = Guid.Parse("4f1d809c-9ccf-4479-b1ab-273f6193679b"), 
                RoleId = Guid.Parse("41330934-5681-4660-bfd0-a7c91940073f")  
            },
            new IdentityUserRole<Guid>
            {
                UserId = Guid.Parse("2d8651fd-3800-48da-a85c-f294282b5180"), 
                RoleId = Guid.Parse("41330934-5681-4660-bfd0-a7c91940073f")  
            },
            new IdentityUserRole<Guid>
            {
                UserId = Guid.Parse("32b60a7d-1f1d-4e78-a968-9aa5a3b074d8"), 
                RoleId = Guid.Parse("41330934-5681-4660-bfd0-a7c91940073f")  
            },
            // Teachers and their roles
            new IdentityUserRole<Guid>
            {
                UserId = Guid.Parse("3e28d8c3-d490-4aaa-ad29-fb93c8e99c27"), 
                RoleId = Guid.Parse("8672057e-cd8e-4f23-b002-f1a2785fe8f3")  
            },
            new IdentityUserRole<Guid>
            {
                UserId = Guid.Parse("a87cdd8b-274d-4334-8528-979ac1f420a9"), 
                RoleId = Guid.Parse("8672057e-cd8e-4f23-b002-f1a2785fe8f3")  
            },
            new IdentityUserRole<Guid>
            {
                UserId = Guid.Parse("e0a405f8-b689-4263-afd2-a35314b7e8d9"), 
                RoleId = Guid.Parse("8672057e-cd8e-4f23-b002-f1a2785fe8f3")  
            }
        };
    }
}
