using CourseApp.Application.ResultDto;
using CourseApp.Domain.Enums;
using MediatR;

namespace CourseApp.Application.Features.Orders.Commands.UpdateOrder;

public record UpdateOrderCommand(Guid Id, Guid CourseId, OrderStasusses OrderStatus) : IRequest<Result>;