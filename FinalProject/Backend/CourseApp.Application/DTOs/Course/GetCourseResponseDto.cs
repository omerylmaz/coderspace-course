namespace CourseApp.Application.DTOs.Course;

public record GetCourseResponseDto
(
    Guid Id,
    string Name,
    decimal Price,
    string CategoryName,
    string Title,
    string ImageUrl
);