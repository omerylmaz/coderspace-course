using AutoMapper;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using Final.Application.Abstractions.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CourseApp.Application.Features.Courses.Commands.UpdateCourse;

internal class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, Result>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UpdateCourseCommandHandler> _logger;
    private readonly IMapper _mapper;

    public UpdateCourseCommandHandler(
        ICourseRepository courseRepository,
        IUnitOfWork unitOfWork,
        ILogger<UpdateCourseCommandHandler> logger,
        IMapper mapper)
    {
        _courseRepository = courseRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<Result> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        var courseDomain = await _courseRepository.GetDetailByIdWithCategoryNameAsync(request.Id, cancellationToken);

        if (courseDomain == null)
        {
            _logger.LogWarning("Course with Id {Id} not found", request.Id);
            return Result.NotFound($"{request.Id} id not found");
        }

        _mapper.Map(request, courseDomain);

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

        _courseRepository.Update(courseDomain);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
