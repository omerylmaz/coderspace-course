using CourseApp.Application.Abstractions.Events;
using CourseApp.Domain.Events;
using MassTransit;
using MassTransit.Transports;

namespace CourseApp.Infrastructure.Messaging.Publishers;

public class EventPublisher(IPublishEndpoint publishEndpoint) : IEventPublisher
{
    public async Task PublishPaymentCompletedEventAsync(Guid userId, Guid courseId, DateTime paymentDate, CancellationToken cancellationToken)
    {
        var paymentCompletedEvent = new PaymentCompletedEvent(userId, courseId, paymentDate);

        await publishEndpoint.Publish(paymentCompletedEvent, cancellationToken);
    }

    public async Task PublishEmailRegisteredAsync(string to, string subject, string body, CancellationToken cancellationToken)
    {
        var emailEvent = new EmailRegisteredEvent(to, subject, body);
        await publishEndpoint.Publish(emailEvent, cancellationToken);
    }
}
