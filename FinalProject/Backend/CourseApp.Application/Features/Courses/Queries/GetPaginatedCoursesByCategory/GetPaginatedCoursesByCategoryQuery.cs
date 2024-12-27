using CourseApp.Application.DTOs.Course;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Pagination;
using Final.Application.Features.Courses.Queries.GetPaginatedCourses;
using MediatR;

namespace CourseApp.Application.Features.Courses.Queries.GetPaginatedCoursesByCategory;

public record GetPaginatedCoursesByCategoryQuery
(
    int PageNumber,
    int PageSize,
    List<string> CategoryNames
) : IRequest<Result<GetPaginatedCoursesByCategoryResponse>>;

public record GetPaginatedCoursesByCategoryResponse(PagedResult<GetCourseResponseDto> Courses);

//public record GetCourseByCategoryResponse
//(
//    Guid Id,
//    string Name,
//    decimal Price,
//    string CategoryName
//);