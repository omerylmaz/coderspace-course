using AutoMapper;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using Final.Application.Abstractions.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CourseApp.Application.Features.Users.Queries.GetUserDetail;

internal class GetUserDetailQueryHandler(UserManager<AppUser> userManager, ICourseRepository courseRepository, IMapper mapper) : IRequestHandler<GetUserDetailQuery, Result<GetUserDetailResponse>>
{
    public async Task<Result<GetUserDetailResponse>> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.UserId.ToString());
        //var courses = await courseRepository.GetPaidCoursesByUserIdAsync(request.UserId, /*request.pageNumber, request.pageSize,*/ cancellationToken);

        //var coursesResponse = mapper.Map<PagedResult<GetCourseResponseDto>>(courses);
        var userDetail = new GetUserDetailResponse(user.FullName, user.UserName, user.Email, user.PhoneNumber/*, courses.TotalCount, coursesResponse*/);
        return Result<GetUserDetailResponse>.Success(userDetail);
    }
}
