using CourseApp.Domain.Entities;
using CourseApp.Infrastructure.Data.SeedData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Final.Infrustructure.Data.EntityConfigurations;

internal class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name)
               .IsRequired()
               .HasMaxLength(200);
        builder.Property(c => c.Description)
               .HasMaxLength(1000);
        builder.Property(c => c.Price)
               .HasColumnType("decimal(18,2)");
        builder.HasOne(c => c.Category)
               .WithMany(cat => cat.Courses)
               .HasForeignKey(c => c.CategoryId);

        builder.HasOne(c => c.Teacher)
            .WithMany()
            .HasForeignKey(c => c.TeacherId);

        builder.HasData(CourseSeeder.SeedCourses());
    }
}