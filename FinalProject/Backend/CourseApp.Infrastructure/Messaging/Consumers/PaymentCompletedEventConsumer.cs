using CourseApp.Application.Abstractions.Repositories;
using CourseApp.Domain.Entities;
using CourseApp.Domain.Events;
using Final.Application.Abstractions.Repositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace CourseApp.Infrastructure.Messaging.Consumers;

public class PaymentCompletedEventConsumer(ICourseRepository courseRepository, 
    IUnitOfWork unitOfWork, 
    INotificationRepository notificationRepository) : IConsumer<PaymentCompletedEvent>
{
    public async Task Consume(ConsumeContext<PaymentCompletedEvent> context)
    {
        var eventMessage = context.Message;
        var cancellationToken = context.CancellationToken;

        var course = await courseRepository.GetByIdWithCategoryNameAsync(eventMessage.CourseId, cancellationToken);

        var notification = new Notification
        {
            UserId = eventMessage.UserId,
            Title = "Payment Completed",
            Message = $"Your payment has been successfully completed with course name <b>{course.Name}</b> and price <b>{course.Price:C}</b>. Payment Date: <b>{eventMessage.PaymentDate:dd.MM.yyyy HH:mm:ss}</b>",
            IsRead = false
        };

        await notificationRepository.AddAsync(notification, cancellationToken);
        await unitOfWork.SaveChangesAsync();

    }
}
