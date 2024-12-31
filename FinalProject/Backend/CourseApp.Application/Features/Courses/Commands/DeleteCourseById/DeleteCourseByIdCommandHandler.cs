using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using Final.Application.Abstractions.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Final.Application.Features.Courses.Commands.DeleteCourseById;

internal class DeleteOrderByIdCommandHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork/*, ICacheService cacheService*/, ILogger<DeleteOrderByIdCommandHandler> logger) : IRequestHandler<DeleteOrderByIdCommand, Result>
{
    public async Task<Result> Handle(DeleteOrderByIdCommand request, CancellationToken cancellationToken)
    {
        Course course = await courseRepository.GetByIdAsync(request.Id, cancellationToken);

        if (course == null)
        {
            logger.LogWarning("Course with Id {Id} not found", request.Id);
            return Result.NotFound($"{request.Id} id not found");
        }

        courseRepository.Delete(course);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        //await cacheService.RemoveByPatternAsync(Constants.CourseS_PAGED, cancellationToken);

        return Result.Success();
    }
}
