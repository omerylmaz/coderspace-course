using CourseApp.Application.ResultDto;
using MediatR;
using System.Text.Json.Serialization;

namespace CourseApp.Application.Features.Orders.Commands.CreateOrder;

public record CreateOrderCommand : IRequest<Result<CreateOrderResponse>>
{
    [JsonIgnore]
    public Guid UserId { get; init; }
    public Guid CourseId { get; init; }
};

public record CreateOrderResponse(Guid Id);