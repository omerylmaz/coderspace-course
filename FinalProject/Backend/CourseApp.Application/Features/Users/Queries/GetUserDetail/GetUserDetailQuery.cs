using CourseApp.Application.DTOs.Course;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Pagination;
using MediatR;

namespace CourseApp.Application.Features.Users.Queries.GetUserDetail;

public record GetUserDetailQuery(Guid UserId/*, int pageNumber, int pageSize*/) : IRequest<Result<GetUserDetailResponse>>;


public record GetUserDetailResponse
(
    string FullName,
    string UserName,
    string Email,
    string PhoneNumber
);