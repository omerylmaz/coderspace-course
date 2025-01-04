using AutoMapper;
using CourseApp.Application.Abstractions.Repositories;
using CourseApp.Application.DTOs.Course;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using CourseApp.Domain.Pagination;
using MediatR;

namespace CourseApp.Application.Features.Courses.Queries.GetPaginatedCoursesByCategory;

internal class GetPaginatedCoursesByCategoryQueryHandler(ICourseRepository courseRepository, IMapper mapper) : IRequestHandler<GetPaginatedCoursesByCategoryQuery, Result<GetPaginatedCoursesByCategoryResponse>>
{
    public async Task<Result<GetPaginatedCoursesByCategoryResponse>> Handle(GetPaginatedCoursesByCategoryQuery request, CancellationToken cancellationToken)
    {
        PagedResult<Course> pagedCourses = await courseRepository.GetPagedByCategoryNamesAsync(request.CategoryNames, request.PageNumber, request.PageSize, cancellationToken);

        var courseResponses = mapper.Map<PagedResult<GetCourseResponseDto>>(pagedCourses);

        var response = new GetPaginatedCoursesByCategoryResponse(courseResponses);

        return Result<GetPaginatedCoursesByCategoryResponse>.Success(response);
    }
}