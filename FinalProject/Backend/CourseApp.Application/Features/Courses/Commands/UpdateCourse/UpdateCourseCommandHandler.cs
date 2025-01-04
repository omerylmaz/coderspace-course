using AutoMapper;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using CourseApp.Application.Abstractions.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using CourseApp.Application.Abstractions.Services;

namespace CourseApp.Application.Features.Courses.Commands.UpdateCourse;

internal class UpdateCourseCommandHandler(
    ICourseRepository courseRepository,
    IUnitOfWork unitOfWork,
    ILogger<UpdateCourseCommandHandler> logger,
    IMapper mapper,
    ICacheService cacheService
        ) : IRequestHandler<UpdateCourseCommand, Result>
{
    public async Task<Result> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        var courseDomain = await courseRepository.GetDetailByIdWithCategoryNameAsync(request.Id, cancellationToken);

        if (courseDomain == null)
        {
            logger.LogWarning("Course with Id {Id} not found", request.Id);
            return Result.NotFound($"{request.Id} id not found");
        }

        mapper.Map(request, courseDomain);

        courseDomain.Contents.Clear();
        foreach (var contentDto in request.Contents)
        {
            var content = new Content
            {
                Title = contentDto.Title,
                Description = contentDto.Description,
                Duration = contentDto.Duration
            };

            courseDomain.Contents.Add(content);
        }

        courseRepository.Update(courseDomain);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        await cacheService.RemoveByPatternAsync(Constants.CacheKeys.COURSES_PAGED, cancellationToken);

        return Result.Success();
    }
}
