using CourseApp.Application.ResultDto;
using MediatR;

namespace CourseApp.Application.Features.Orders.Commands.DeleteOrderById;

public record DeleteOrderByIdCommand
(
    Guid Id
) : IRequest<Result>;