using CourseApp.Application.DTOs.Course;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Pagination;
using MediatR;

namespace CourseApp.Application.Features.Courses.Queries.GetPaidCoursesByUserId;

public record GetPaidCoursesByUserIdQuery(Guid UserId, int PageNumber, int PageSize) : IRequest<Result<GetPaidCoursesByUserIdResponse>>;

public record GetPaidCoursesByUserIdResponse(PagedResult<GetCourseResponseDto> Courses);

//public record GetPaidCourseByUserIdResponse
//(
//    Guid Id,
//    string Name,
//    decimal Price,
//    string CategoryName
//);