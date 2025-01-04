using AutoMapper;
using CourseApp.Application.Abstractions.Repositories;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Pagination;
using MediatR;

namespace CourseApp.Application.Features.Notifications.Queries.GetPaginatedNotifications;

internal class GetPaginatedNotificationsQueryHandler(
    INotificationRepository notificationRepository, 
    ICourseRepository courseRepository,
    IMapper mapper) : IRequestHandler<GetPaginatedNotificationsQuery, Result<GetPaginatedNotificationsResponse>>
{
    public async Task<Result<GetPaginatedNotificationsResponse>> Handle(GetPaginatedNotificationsQuery request, CancellationToken cancellationToken)
    {
        var notifications = await notificationRepository.GetPagedByOrder(x => x.UserId == request.UserId, request.PageNumber, request.PageSize, cancellationToken);

        var notificationsResponse = mapper.Map<PagedResult<GetNotificationResponse>>(notifications);

        var response = new GetPaginatedNotificationsResponse(notificationsResponse);

        return Result<GetPaginatedNotificationsResponse>.Success(response);
    }
}
