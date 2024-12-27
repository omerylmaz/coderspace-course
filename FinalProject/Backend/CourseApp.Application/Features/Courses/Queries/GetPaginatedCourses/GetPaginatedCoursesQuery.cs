using CourseApp.Application.DTOs.Course;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Pagination;
using MediatR;

namespace Final.Application.Features.Courses.Queries.GetPaginatedCourses;

public record GetPaginatedCoursesQuery
    (
    int PageNumber,
    int PageSize
    ) : IRequest<Result<GetPaginatedCoursesResponse>>;

public record GetPaginatedCoursesResponse(PagedResult<GetCourseResponseDto> Courses);

//public record GetCourseResponse
//(
//    Guid Id,
//    string Name,
//    decimal Price,
//    string CategoryName
//);