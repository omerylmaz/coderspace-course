using CourseApp.Application.ResultDto;
using CourseApp.Domain.Pagination;
using MediatR;

namespace Final.Application.Features.Courses.Queries.GetPaginatedCourses;

public record GetPaginatedOrdersQuery(Guid UserId, int PageNumber, int PageSize) : IRequest<Result<GetPaginatedOrdersResponse>>;

public record GetPaginatedOrdersResponse(PagedResult<GetOrderResponse> Orders);

public record GetOrderResponse(Guid Id, Guid UserId, Guid CourseId, DateTime OrderDate);
