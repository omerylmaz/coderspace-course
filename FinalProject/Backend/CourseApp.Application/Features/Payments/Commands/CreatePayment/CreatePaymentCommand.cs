using CourseApp.Application.ResultDto;
using MediatR;
using System.Text.Json.Serialization;

namespace CourseApp.Application.Features.Payments.Commands.CreatePayment;

public record CreatePaymentCommand : IRequest<Result<CreatePaymentResponse>>
{
    [JsonIgnore]
    public Guid UserID { get; init; }
    public string CardHolderName { get; init; }
    public string CardNumber { get; init; }
    public string ExpireMonth { get; init; }
    public string ExpireYear { get; init; }
    public string Cvc { get; init; }
    public Guid CourseId { get; init; }
};


public record CreatePaymentResponse(string HtmlContent, string ConversationId);