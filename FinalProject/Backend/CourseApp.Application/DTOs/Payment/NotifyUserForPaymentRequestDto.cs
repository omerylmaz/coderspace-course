namespace CourseApp.Application.DTOs.Payment;

public record NotifyUserForPaymentRequestDto 
{
    public string ConversationId { get; init; }
    public string Message { get; init; }
    public string? ErrorMessage { get; init; }
}