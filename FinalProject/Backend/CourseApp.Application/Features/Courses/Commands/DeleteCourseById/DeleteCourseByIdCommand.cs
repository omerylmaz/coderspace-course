using CourseApp.Application.ResultDto;
using MediatR;

namespace Final.Application.Features.Courses.Commands.DeleteCourseById;

public record DeleteOrderByIdCommand
(
    Guid Id
) : IRequest<Result>;