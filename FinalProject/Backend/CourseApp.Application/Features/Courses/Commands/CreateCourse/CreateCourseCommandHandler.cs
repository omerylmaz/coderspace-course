using AutoMapper;
using CourseApp.Application.Abstractions.Repositories;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using Final.Application.Features.Courses.Commands.CreateCourse;
using MediatR;

namespace CourseApp.Application.Features.Courses.Commands.CreateCourse;

internal class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, Result<CreateCourseResponse>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICourseRepository _courseRepository;

    public CreateCourseCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ICourseRepository courseRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _courseRepository = courseRepository;
    }

    public async Task<Result<CreateCourseResponse>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var course = _mapper.Map<Course>(request);

        if (request.Contents != null && request.Contents.Count > 0)
        {
            course.Contents = request.Contents.Select(contentDto => new Content
            {
                Title = contentDto.Title,
                Description = contentDto.Description,
                Duration = TimeSpan.Parse(contentDto.Duration)
            }).ToList();
        }

        await _courseRepository.AddAsync(course, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var response = new CreateCourseResponse(course.Id);
        return Result<CreateCourseResponse>.Success(response);
    }
}
