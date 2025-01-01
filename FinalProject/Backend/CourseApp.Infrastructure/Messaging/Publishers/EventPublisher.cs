using CourseApp.Application.Abstractions.Events;
using CourseApp.Domain.Events;
using MassTransit;

namespace CourseApp.Infrastructure.Messaging.Publishers;

public class EventPublisher(IPublishEndpoint publishEndpoint) : IEventPublisher
{
    public async Task PublishPaymentCompletedEventAsync(Guid userId, Guid courseId, DateTime paymentDate, CancellationToken cancellationToken)
    {
        var paymentCompletedEvent = new PaymentCompletedEvent(userId, courseId, paymentDate);

        await publishEndpoint.Publish(paymentCompletedEvent, cancellationToken);
    }
}
