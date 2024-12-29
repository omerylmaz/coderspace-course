namespace CourseApp.Application.DTOs.Payment;

public record PaymentCallbackData
(
    string Status,
    string PaymentId,
    string ConversationData,
    string MDStatus,
    long ConversationId
);
