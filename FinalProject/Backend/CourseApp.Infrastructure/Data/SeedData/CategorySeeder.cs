using CourseApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CourseApp.Infrastructure.Data.SeedData;

internal static class CategorySeeder
{
    public static List<Category> SeedCategories()
    {
        List<Category> categories = 
            [
                new Category { Id = Guid.Parse("4290c1e9-2c24-45d1-8d7b-35482a001044"), Name = "Software", CreatedDate = DateTime.Now },
                new Category { Id = Guid.Parse("a82c256f-6027-4c22-87ca-22fb85c2daf6"), Name = "Design", CreatedDate = DateTime.Now },
                new Category { Id = Guid.Parse("a2308a61-470a-46e9-ba82-87c3090046fb"), Name = "Marketing", CreatedDate = DateTime.Now },
                new Category { Id = Guid.Parse("80853207-5355-434f-8cab-80e3269d54c4"), Name = "Project Management", CreatedDate = DateTime.Now },
                new Category { Id = Guid.Parse("551963a2-879e-45a6-99a6-5eb512b775c0"), Name = "Finance", CreatedDate = DateTime.Now },
                new Category { Id = Guid.Parse("8b48bba4-8acd-4ff2-b669-f4095c885e90"), Name = "Lifestyle", CreatedDate = DateTime.Now },
                new Category { Id = Guid.Parse("a93961af-166d-461c-a6db-263c4d48a55d"), Name = "Photography", CreatedDate = DateTime.Now }
            ];
        return categories;
    }
}
