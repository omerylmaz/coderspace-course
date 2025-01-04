using AutoMapper;
using CourseApp.Application.Abstractions.Repositories;
using CourseApp.Application.DTOs.Course;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Pagination;
using MediatR;

namespace CourseApp.Application.Features.Courses.Queries.GetPaginatedTeacherCourses;

internal class GetPaginatedTeacherCoursesCommandHandler(
    ICourseRepository courseRepository,
    IMapper mapper) : IRequestHandler<GetPaginatedTeacherCoursesCommand, Result<GetPaginatedTeacherCoursesResponse>>
{
    public async Task<Result<GetPaginatedTeacherCoursesResponse>> Handle(GetPaginatedTeacherCoursesCommand request, CancellationToken cancellationToken)
    {
        var courses = await courseRepository.GetPagedWhereAsync(x => x.TeacherId == request.TeacherId, request.PageNumber, request.PageSize, cancellationToken);
        var courseResponses = mapper.Map<PagedResult<GetCourseResponseDto>>(courses);

        var coursesResponse = new GetPaginatedTeacherCoursesResponse(courseResponses);
        return Result<GetPaginatedTeacherCoursesResponse>.Success(coursesResponse);
    }
}
