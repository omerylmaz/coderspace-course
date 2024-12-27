using AutoMapper;
using Final.Application.Abstractions.Repositories;
using Final.Application;
using Final.Application.Abstractions.Repositories;
using Final.Application.Abstractions.Services;
using MediatR;
using CourseApp.Domain.Entities;
using CourseApp.Application.ResultDto;

namespace Final.Application.Features.Courses.Commands.UpdateCourse;

internal class UpdateOrderCommandHandler(ICourseRepository courseRepository, IMapper mapper, IUnitOfWork unitOfWork/*, ICacheService cacheService*/) : IRequestHandler<UpdateCourseCommand, Result>
{
    public async Task<Result> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        Course courseDomain = await courseRepository.GetByIdAsync(request.Id, cancellationToken);

        if (courseDomain == null)
            return Result.NotFound($"{request.Id} id not found");

        mapper.Map(request, courseDomain);
        courseRepository.Update(courseDomain);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        //await cacheService.RemoveByPatternAsync(Constants.COURSES_PAGED, cancellationToken);
        return Result.Success();
    }
}
