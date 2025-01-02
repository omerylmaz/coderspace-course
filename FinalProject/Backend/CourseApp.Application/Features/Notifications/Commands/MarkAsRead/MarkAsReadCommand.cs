using CourseApp.Application.ResultDto;
using MediatR;
using System.Security.Principal;
using System.Text.Json.Serialization;

namespace CourseApp.Application.Features.Notifications.Commands.MarkAsRead;

public class MarkAsReadCommand : IRequest<Result>
{
    [JsonIgnore]
    public Guid UserId { get; set; }

    public Guid NotificationId { get; set; }
}