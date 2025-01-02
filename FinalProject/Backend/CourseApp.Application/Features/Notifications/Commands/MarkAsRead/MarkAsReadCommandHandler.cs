using CourseApp.Application.Abstractions.Repositories;
using CourseApp.Application.ResultDto;
using Final.Application.Abstractions.Repositories;
using Final.Application.Features.Courses.Queries.GetCourseById;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CourseApp.Application.Features.Notifications.Commands.MarkAsRead;

internal class MarkAsReadCommandHandler(INotificationRepository notificationRepository, 
    ILogger<MarkAsReadCommandHandler> logger,
    IUnitOfWork unitOfWork) : IRequestHandler<MarkAsReadCommand, Result>
{
    public async Task<Result> Handle(MarkAsReadCommand request, CancellationToken cancellationToken)
    {
        var notification = await notificationRepository.GetByIdAsync(request.NotificationId, cancellationToken);
        if (notification is null)
        {
            logger.LogWarning("Notification with Id {Id} not found", request.NotificationId);
            return Result.NotFound($"Notification with {request.NotificationId} not found");
        }

        if (notification.UserId != request.UserId)
        {
            logger.LogWarning("Notification with Id {NotificationId} does not belong to user {UserId}", request.NotificationId, request.UserId);
            return Result.Conflict($"Entered notification does not belong to user");
        }

        notification.IsRead = true;
        notificationRepository.Update(notification);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
