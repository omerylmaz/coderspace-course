using AutoMapper;
using CourseApp.Application.Abstractions.Repositories;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Final.Application.Features.Courses.Queries.GetCourseById
{
    internal class GetCourseByIdQueryHandler(ICourseRepository courseRepository, IMapper mapper, ILogger<GetCourseByIdQueryHandler> logger) : IRequestHandler<GetCourseByIdQuery, Result<GetCourseByIdResponse>>
    {
        public async Task<Result<GetCourseByIdResponse>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            Course courseDomain = await courseRepository.GetDetailByIdWithCategoryNameAsync(request.Id, cancellationToken);
            if (courseDomain == null)
            {
                logger.LogWarning("Course with Id {Id} not found", request.Id);
                return Result<GetCourseByIdResponse>.NotFound($"Course with {request.Id} not found");
            }

            GetCourseByIdResponse courseResponse = mapper.Map<GetCourseByIdResponse>(courseDomain);
            return Result<GetCourseByIdResponse>.Success(courseResponse);
        }
    }
}
