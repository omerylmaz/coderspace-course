using CourseApp.Application.ResultDto;
using MediatR;

namespace CourseApp.Application.Features.Courses.Queries.GetCourseById;

public record GetOrderByIdQuery(Guid Id) : IRequest<Result<GetOrderByIdResponse>>;

public record GetOrderByIdResponse(Guid Id, Guid UserId, Guid CourseId, DateTime OrderDate);
