using CourseApp.Application.ResultDto;
using MediatR;

namespace CourseApp.Application.Features.Courses.Queries.BestSellingCourses;

public record BestSellingCoursesQuery(int Count) : IRequest<Result<List<BestSellingCourseResponse>>>;


public record BestSellingCourseResponse(Guid CourseId, string Name, string Title, decimal Price, string ImageUrl, int SalesCount);