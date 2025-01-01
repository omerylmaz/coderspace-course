using CourseApp.Domain.Entities;
using CourseApp.Infrastructure.Data.SeedData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Final.Infrustructure.Data.EntityConfigurations;

internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasMany(c => c.Courses)
            .WithOne(c => c.Category);
        builder.Property(c => c.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.HasData(CategorySeeder.SeedCategories());
    }
}