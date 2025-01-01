using CourseApp.Infrastructure.Data.SeedData;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CourseApp.Domain.Entities;

namespace CourseApp.Infrastructure.Data.EntityConfigurations;


internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasData(UserSeeder.SeedUsers());
    }
}