using CourseApp.Application.ResultDto;
using CourseApp.Domain.Enums;
using MediatR;

namespace CourseApp.Application.Features.Orders.Commands.CompleteOrder;

public record CompleteOrderCommand(
    string Status,
    string PaymentId,
    string ConversationData,
    string MDStatus,
    string ConversationId) : IRequest<Result>;