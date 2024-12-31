using AutoMapper;
using CourseApp.Application.DTOs.Course;
using CourseApp.Application.Features.Courses.Queries.GetPaginatedCourses;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using CourseApp.Domain.Pagination;
using Final.Application.Abstractions.Repositories;
using MediatR;
using System.Linq.Expressions;

namespace Final.Application.Features.Courses.Queries.GetPaginatedCourses;

internal class GetPaginatedCoursesQueryHandler : IRequestHandler<GetPaginatedCoursesQuery, Result<GetPaginatedCoursesResponse>>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public GetPaginatedCoursesQueryHandler(ICourseRepository courseRepository, IMapper mapper)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
    }

    public async Task<Result<GetPaginatedCoursesResponse>> Handle(GetPaginatedCoursesQuery request, CancellationToken cancellationToken)
    {
        PagedResult<Course> pagedCourses = await _courseRepository.GetPagedWithCategoryNameAsync(request.PageNumber, request.PageSize, cancellationToken);

        var courseResponses = _mapper.Map<PagedResult<GetCourseResponseDto>>(pagedCourses);

        var response = new GetPaginatedCoursesResponse(courseResponses);

        return Result<GetPaginatedCoursesResponse>.Success(response);
    }
}
