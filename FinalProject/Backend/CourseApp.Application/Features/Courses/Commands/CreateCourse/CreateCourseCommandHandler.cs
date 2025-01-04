using AutoMapper;
using CourseApp.Application.Abstractions.Repositories;
using CourseApp.Application.Abstractions.Services;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using Final.Application.Features.Courses.Commands.CreateCourse;
using MediatR;

namespace CourseApp.Application.Features.Courses.Commands.CreateCourse;

internal class CreateCourseCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ICourseRepository courseRepository, ICacheService cacheService) 
    : IRequestHandler<CreateCourseCommand, Result<CreateCourseResponse>>
{
    public async Task<Result<CreateCourseResponse>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var course = mapper.Map<Course>(request);

        if (request.Contents != null && request.Contents.Count > 0)
        {
            course.Contents = request.Contents.Select(contentDto => new Content
            {
                Title = contentDto.Title,
                Description = contentDto.Description,
                Duration = TimeSpan.Parse(contentDto.Duration)
            }).ToList();
        }

        await courseRepository.AddAsync(course, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        await cacheService.RemoveByPatternAsync(Constants.CacheKeys.COURSES_PAGED, cancellationToken);

        var response = new CreateCourseResponse(course.Id);
        return Result<CreateCourseResponse>.Success(response);
    }
}
