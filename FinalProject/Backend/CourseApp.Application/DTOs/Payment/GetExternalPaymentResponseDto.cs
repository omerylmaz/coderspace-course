namespace CourseApp.Application.DTOs.Payment;

public record GetExternalPaymentResponseDto
{
    public string HtmlContent { get; init; }
    public string ConversationId { get; init; }
}
