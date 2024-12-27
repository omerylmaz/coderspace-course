using AutoMapper;
using Final.Application.Abstractions.Repositories;
using Final.Application.Abstractions.Repositories;
using MediatR;
using CourseApp.Domain.Entities;
using CourseApp.Application.ResultDto;

namespace Final.Application.Features.Courses.Commands.CreateCourse;

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
        await _courseRepository.AddAsync(course, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var response = new CreateCourseResponse(course.Id);
        return Result<CreateCourseResponse>.Success(response);
    }
}