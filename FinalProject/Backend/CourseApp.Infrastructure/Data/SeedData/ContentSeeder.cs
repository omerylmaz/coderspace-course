using Bogus;
using CourseApp.Domain.Entities;

namespace CourseApp.Infrastructure.Data.SeedData;

internal static class ContentSeeder
{
    public static List<Content> SeedContents()
    {
        var courseIds = GetCourseIds();
        var contents = new List<Content>();

        var faker = new Faker();

        foreach (var courseId in courseIds)
        {
            for (int i = 0; i < 5; i++)
            {
                contents.Add(new Content
                {
                    Id = Guid.NewGuid(),
                    CourseId = courseId,
                    Title = faker.Lorem.Sentence(5),
                    Description = faker.Lorem.Paragraph(3),
                    CreatedDate = DateTime.Now,
                    Duration = TimeSpan.FromMinutes(faker.Random.Int(5, 40))
                });
            }
        }

        return contents;
    }


    private static List<Guid> GetCourseIds()
    {
        var courseIds = new List<Guid>
        {
            Guid.Parse("7f16ad2a-473f-47a9-b26d-523e9f9cf805"),
            Guid.Parse("e7d6ad2a-473f-47a9-b26d-523e9f9cf806"),
            Guid.Parse("cb89ad2a-473f-47a9-b26d-523e9f9cf807"),
            Guid.Parse("a29eac2a-473f-47a9-b26d-523e9f9cf808"),
            Guid.Parse("f45bda6a-473f-47a9-b26d-523e9f9cf809"),
            Guid.Parse("d32f93ae-13f3-452f-97c1-0f9dc7c09300"),
            Guid.Parse("78cb6b7a-5b7e-4977-8e91-31cd22f2e442"),
            Guid.Parse("1bfc9db7-3433-4b42-9f5c-bf3c01a8099a"),
            Guid.Parse("3bff33b4-2c5e-4c42-8a73-1d7e7c4d99f3"),
            Guid.Parse("7c9e8ba2-2b7d-4e47-87e2-92d8e6f8b6a3"),
            Guid.Parse("5e7f2b9c-b3f5-4c42-9f7e-8b32e2f8d8a7"),
            Guid.Parse("2b9f7e8d-b4f6-4c3d-8c9f-6b23e7d9f3a2"),
            Guid.Parse("9c8f7e2d-b4a6-4f9d-8b32-99f7e6f9b3a4"),
            Guid.Parse("b7e6d3c4-2e4f-4c7a-87e6-7d8f9b32c6a5"),
            Guid.Parse("8b6c9d7e-2f4b-47a6-87e6-7b9c4f6a9d3e"),
            Guid.Parse("9f3c8e7b-2d4e-4c7a-87f7-7b9d8c4f6a9e"),
            Guid.Parse("9b6d7e3c-2e4f-48a7-9c3b-7e9f8d4c6a7e"),
            Guid.Parse("a2c4d9b8-3e4f-47a6-98f7-7d6c9f8e4a7b"),
            Guid.Parse("f7d6c9b8-3e7f-4c6b-98f7-7e9d8c4f6a9b"),
            Guid.Parse("b6c8e7d9-2e4b-4c3f-98f7-7e6b9c4a9d8f"),
            Guid.Parse("fc8dca73-6833-4d5f-9c76-73e7fd8ce9d4"),
            Guid.Parse("4bced12f-c5b0-484d-8fd6-a9557329b1e0"),
            Guid.Parse("b71f2993-7de5-4175-8421-875eb7323b5a"),
            Guid.Parse("2dea5bce-36b6-457a-9a31-4626f9b213ec"),
            Guid.Parse("24eb5fb1-e5cb-4318-8612-ef01d60a09ef")
            };

        return courseIds; 
    }
}
