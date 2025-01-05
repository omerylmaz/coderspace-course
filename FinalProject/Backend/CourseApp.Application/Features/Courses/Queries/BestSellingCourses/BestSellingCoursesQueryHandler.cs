using AutoMapper;
using CourseApp.Application.Abstractions.Repositories;
using CourseApp.Application.ResultDto;
using MediatR;
using System.Collections.Generic;

namespace CourseApp.Application.Features.Courses.Queries.BestSellingCourses;

internal class BestSellingCoursesQueryHandler(ICourseRepository courseRepository, IMapper mapper) : IRequestHandler<BestSellingCoursesQuery, Result<List<BestSellingCourseResponse>>>
{
    public async Task<Result<List<BestSellingCourseResponse>>> Handle(BestSellingCoursesQuery request, CancellationToken cancellationToken)
    {
        var bestSellingCourses = await courseRepository.GetBestSellingCoursesAsync(request.Count, cancellationToken);

        var bestSellingCoursesResponse = mapper.Map<List<BestSellingCourseResponse>>(bestSellingCourses);

        return Result<List<BestSellingCourseResponse>>.Success(bestSellingCoursesResponse);
    }
}
