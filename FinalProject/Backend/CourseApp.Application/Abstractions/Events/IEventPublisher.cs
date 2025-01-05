namespace CourseApp.Application.Abstractions.Events;

public interface IEventPublisher
{
    Task PublishPaymentCompletedEventAsync(Guid userId, Guid courseId, DateTime paymentDate, CancellationToken cancellationToken);
    Task PublishEmailRegisteredAsync(string to, string subject, string body, CancellationToken cancellationToken);
}