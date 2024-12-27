using AutoMapper;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using Final.Application.Abstractions.Repositories;
using MediatR;

namespace Final.Application.Features.Courses.Queries.GetCourseById
{
    internal class GetCourseByIdQueryHandler(ICourseRepository courseRepository, IMapper mapper) : IRequestHandler<GetCourseByIdQuery, Result<GetCourseByIdResponse>>
    {
        public async Task<Result<GetCourseByIdResponse>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            Course courseDomain = await courseRepository.GetByIdAsync(request.Id, cancellationToken);
            if (courseDomain == null)
                return Result<GetCourseByIdResponse>.NotFound($"Course with {request.Id} not found");

            GetCourseByIdResponse courseResponse = mapper.Map<GetCourseByIdResponse>(courseDomain);
            return Result<GetCourseByIdResponse>.Success(courseResponse);
        }
    }
}
