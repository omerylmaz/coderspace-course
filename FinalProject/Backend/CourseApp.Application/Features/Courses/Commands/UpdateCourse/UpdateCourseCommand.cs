using CourseApp.Application.ResultDto;
using MediatR;

namespace Final.Application.Features.Courses.Commands.UpdateCourse;

public record UpdateCourseCommand
(
    Guid Id,
    string Name,
    string Title,
    string Description,
    decimal Price,
    Guid CategoryId,
    string ImageUrl
) : IRequest<Result>;