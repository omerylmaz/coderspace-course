using Microsoft.AspNetCore.Identity;

namespace CourseApp.Domain.Entities;

public class AppUser : IdentityUser<Guid>
{
    public string FullName { get; set; }
}
