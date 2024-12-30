using CourseApp.Application.ResultDto;
using MediatR;

namespace Final.Application.Features.Courses.Commands.CreateCourse;

public record CreateCourseCommand : IRequest<Result<CreateCourseResponse>>
{
    public string Name { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
    public Guid CategoryId { get; init; }
    public string ImageUrl { get; set; }
};

public record CreateCourseResponse(Guid Id);
