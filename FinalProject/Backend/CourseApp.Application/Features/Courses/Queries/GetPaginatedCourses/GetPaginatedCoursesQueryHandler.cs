using AutoMapper;
using CourseApp.Application.Abstractions.Repositories;
using CourseApp.Application.Abstractions.Services;
using CourseApp.Application.DTOs.Course;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using CourseApp.Domain.Pagination;
using MediatR;

namespace CourseApp.Application.Features.Courses.Queries.GetPaginatedCourses;

internal class GetPaginatedCoursesQueryHandler : IRequestHandler<GetPaginatedCoursesQuery, Result<GetPaginatedCoursesResponse>>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;

    public GetPaginatedCoursesQueryHandler(ICourseRepository courseRepository, IMapper mapper, ICacheService cacheService)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
        _cacheService = cacheService;
    }

    public async Task<Result<GetPaginatedCoursesResponse>> Handle(GetPaginatedCoursesQuery request, CancellationToken cancellationToken)
    {
        string cacheKey = $"{Constants.CacheKeys.COURSES_PAGED}_{request.PageNumber}_{request.PageSize}";

        var cachedPagedCourses = await _cacheService.GetAsync<PagedResult<GetCourseResponseDto>>(cacheKey, cancellationToken);
        if (cachedPagedCourses != null)
        {
            var cachedResponse = new GetPaginatedCoursesResponse(cachedPagedCourses);
            return Result<GetPaginatedCoursesResponse>.Success(cachedResponse);
        }

        PagedResult<Course> pagedCourses = await _courseRepository.GetPagedWithCategoryNameAsync(request.PageNumber, request.PageSize, cancellationToken);

        var courseResponses = _mapper.Map<PagedResult<GetCourseResponseDto>>(pagedCourses);

        await _cacheService.SetAsync(cacheKey, courseResponses, cancellationToken, TimeSpan.FromMinutes(10));

        var response = new GetPaginatedCoursesResponse(courseResponses);
        return Result<GetPaginatedCoursesResponse>.Success(response);
    }
}
