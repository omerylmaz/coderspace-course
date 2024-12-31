using CourseApp.Application.Abstractions.Repositories;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using Final.Application.Abstractions.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CourseApp.Application.Features.Orders.Commands.DeleteOrderById;

internal class DeleteOrderByIdCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork,
    ILogger<DeleteOrderByIdCommandHandler> logger) : IRequestHandler<DeleteOrderByIdCommand, Result>
{
    public async Task<Result> Handle(DeleteOrderByIdCommand request, CancellationToken cancellationToken)
    {
        Order order = await orderRepository.GetByIdAsync(request.Id, cancellationToken);

        if (order == null)
        {
            logger.LogWarning("Order with ID {OrderId} not found", request.Id);
            return Result.NotFound($"{request.Id} id not found");
        }

        orderRepository.Delete(order);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

}
