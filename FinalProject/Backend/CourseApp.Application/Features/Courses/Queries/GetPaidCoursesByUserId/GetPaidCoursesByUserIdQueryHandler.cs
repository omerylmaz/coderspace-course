using AutoMapper;
using CourseApp.Application.DTOs.Course;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using CourseApp.Domain.Pagination;
using Final.Application.Abstractions.Repositories;
using MediatR;

namespace CourseApp.Application.Features.Courses.Queries.GetPaidCoursesByUserId;

internal class GetPaidCoursesByUserIdQueryHandler(ICourseRepository courseRepository, IMapper mapper) : IRequestHandler<GetPaidCoursesByUserIdQuery, Result<GetPaidCoursesByUserIdResponse>>
{
    public async Task<Result<GetPaidCoursesByUserIdResponse>> Handle(GetPaidCoursesByUserIdQuery request, CancellationToken cancellationToken)
    {
        PagedResult<Course> pagedCourses = await courseRepository.GetPaidCoursesByUserIdAsync(request.UserId, request.PageNumber, request.PageSize, cancellationToken);

        var courseResponses = mapper.Map<PagedResult<GetCourseResponseDto>>(pagedCourses);

        var response = new GetPaidCoursesByUserIdResponse(courseResponses);

        return Result<GetPaidCoursesByUserIdResponse>.Success(response);
    }
}
