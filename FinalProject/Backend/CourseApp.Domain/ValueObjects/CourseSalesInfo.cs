namespace CourseApp.Domain.ValueObjects;

public record CourseSalesInfo(
    Guid CourseId,
    string Name,
    string Title,
    decimal Price,
    string ImageUrl,
    int SalesCount
);
