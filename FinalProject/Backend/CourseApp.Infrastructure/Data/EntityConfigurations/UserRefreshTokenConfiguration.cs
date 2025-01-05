using CourseApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace CourseApp.Infrastructure.Data.EntityConfigurations;

internal class UserRefreshTokenConfiguration : IEntityTypeConfiguration<UserRefreshToken>
{
    public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
    {
        builder.HasKey(x => new { x.Id, x.UserId});
        builder
            .HasOne(urt => urt.User)
            .WithOne()
            .HasForeignKey<UserRefreshToken>(urt => urt.UserId);
        builder.Property(x => x.Code).IsRequired().HasMaxLength(200);
    }
}