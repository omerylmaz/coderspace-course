using CourseApp.Application.ResultDto;
using MediatR;

namespace CourseApp.Application.Features.Orders.Commands.UpdateOrder;

public record UpdateOrderCommand(Guid Id, Guid CourseId) : IRequest<Result>;