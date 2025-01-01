using CourseApp.Application.ResultDto;
using CourseApp.Domain.Pagination;
using MediatR;
using System.Text.Json.Serialization;

namespace CourseApp.Application.Features.Notifications.Queries.GetPaginatedNotifications;

public record GetPaginatedNotificationsQuery : IRequest<Result<GetPaginatedNotificationsResponse>>
{
    [JsonIgnore]
    public Guid UserId { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}


public record GetPaginatedNotificationsResponse(PagedResult<GetNotificationResponse> Notifications);

public record GetNotificationResponse(string Title, string Message, bool IsRead);