namespace CourseApp.Domain.Events;

public record PaymentCompletedEvent
(
    Guid UserId,
    Guid CourseId,
    DateTime PaymentDate
);