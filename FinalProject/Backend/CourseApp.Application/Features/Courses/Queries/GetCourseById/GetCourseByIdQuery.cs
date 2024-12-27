using CourseApp.Application.ResultDto;
using MediatR;

namespace Final.Application.Features.Courses.Queries.GetCourseById;

public record GetCourseByIdQuery(Guid Id) : IRequest<Result<GetCourseByIdResponse>>;


public record GetCourseByIdResponse
(
    string Name,
    string Title,
    string Description,
    decimal Price,
    string CategoryName
    // int orderCount
);
