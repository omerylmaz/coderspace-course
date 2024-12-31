using CourseApp.Application.DTOs.Course;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Pagination;
using MediatR;
using System.Text.Json.Serialization;

namespace CourseApp.Application.Features.Courses.Queries.GetPaginatedTeacherCourses;

public record GetPaginatedTeacherCoursesCommand : IRequest<Result<GetPaginatedTeacherCoursesResponse>>
{
    [JsonIgnore]
    public Guid TeacherId { get; init; }
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
}

public record GetPaginatedTeacherCoursesResponse
(
    PagedResult<GetCourseResponseDto> Courses
);
