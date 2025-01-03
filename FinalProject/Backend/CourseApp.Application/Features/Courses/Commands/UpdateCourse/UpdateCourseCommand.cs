using CourseApp.Application.ResultDto;
using MediatR;

namespace CourseApp.Application.Features.Courses.Commands.UpdateCourse;

public record UpdateCourseCommand
(
    Guid Id,
    string Name,
    string Title,
    string Description,
    decimal Price,
    Guid CategoryId,
    string ImageUrl,
    List<UpdateCourseContentCommand> Contents
) : IRequest<Result>;

public record UpdateCourseContentCommand
(
    Guid Id,
    string Title,
    string Description,
    TimeSpan Duration
);
