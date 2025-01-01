using CourseApp.Domain.Entities;
using CourseApp.Infrastructure.Data.SeedData;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.Infrastructure.Data.EntityConfigurations;

internal class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
{
    public void Configure(EntityTypeBuilder<AppRole> builder)
    {
        builder.HasData(RoleSeeder.SeedRoles());
    }
}