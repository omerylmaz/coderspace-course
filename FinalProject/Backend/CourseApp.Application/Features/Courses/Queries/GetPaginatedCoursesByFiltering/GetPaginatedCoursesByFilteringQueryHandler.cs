using AutoMapper;
using CourseApp.Application.Abstractions.Repositories;
using CourseApp.Application.DTOs.Course;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Pagination;
using MediatR;

namespace CourseApp.Application.Features.Courses.Queries.GetPaginatedCoursesByFiltering;

internal class GetPaginatedCoursesByFilteringQueryHandler(IMapper mapper, ICourseRepository courseRepository) : IRequestHandler<GetPaginatedCoursesByFilteringQuery, Result<GetPaginatedCoursesByFilteringResponse>>
{
    public async Task<Result<GetPaginatedCoursesByFilteringResponse>> Handle(GetPaginatedCoursesByFilteringQuery request, CancellationToken cancellationToken)
    {
        var pagedResult = await courseRepository.GetPagedCoursesByFilteringAsync(request.Name, request.Title, request.CategoryName, 
            request.Description, request.PageNumber, request.PageSize, cancellationToken);

        var courseResponses = mapper.Map<PagedResult<GetCourseResponseDto>>(pagedResult);

        return Result<GetPaginatedCoursesByFilteringResponse>.Success(new GetPaginatedCoursesByFilteringResponse(courseResponses));
    }
}