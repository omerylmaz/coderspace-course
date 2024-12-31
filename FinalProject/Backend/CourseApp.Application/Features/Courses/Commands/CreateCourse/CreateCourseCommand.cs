using CourseApp.Application.ResultDto;
using MediatR;
using System.Text.Json.Serialization;

namespace Final.Application.Features.Courses.Commands.CreateCourse;

public record CreateCourseCommand : IRequest<Result<CreateCourseResponse>>
{
    [JsonIgnore]
    public Guid TeacherId { get; init; }
    public string Name { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
    public Guid CategoryId { get; init; }
    public string ImageUrl { get; init; }
};

public record CreateCourseResponse(Guid Id);
