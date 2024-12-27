using AutoMapper;
using CourseApp.Application.DTOs.Course;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using CourseApp.Domain.Pagination;
using Final.Application.Abstractions.Repositories;
using MediatR;
using System.Linq.Expressions;

namespace CourseApp.Application.Features.Courses.Queries.GetPaginatedCoursesByFiltering;

internal class GetPaginatedCoursesByFilteringQueryHandler(IMapper mapper, ICourseRepository courseRepository) : IRequestHandler<GetPaginatedCoursesByFilteringQuery, Result<GetPaginatedCoursesByFilteringResponse>>
{
    public async Task<Result<GetPaginatedCoursesByFilteringResponse>> Handle(GetPaginatedCoursesByFilteringQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Course, bool>> predicate = course =>
            (string.IsNullOrEmpty(request.Name) || course.Name.Contains(request.Name)) &&
            (string.IsNullOrEmpty(request.Title) || course.Title.Contains(request.Title)) &&
            (string.IsNullOrEmpty(request.Description) || course.Description.Contains(request.Description));

        var pagedResult = await courseRepository.GetPagedWhereAsync(predicate, request.PageNumber, request.PageSize, cancellationToken);

        var courseResponses = mapper.Map<PagedResult<GetCourseResponseDto>>(pagedResult);

        return Result<GetPaginatedCoursesByFilteringResponse>.Success(new GetPaginatedCoursesByFilteringResponse(courseResponses));
    }
}