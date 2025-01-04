using AutoMapper;
using CourseApp.Application.Abstractions.Repositories;
using CourseApp.Application.ResultDto;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CourseApp.Application.Features.Orders.Commands.UpdateOrder;

internal class UpdateOrderCommandHandler(
    IOrderRepository orderRepository, 
    IMapper mapper, 
    IUnitOfWork unitOfWork,
    ILogger<UpdateOrderCommandHandler> logger) : IRequestHandler<UpdateOrderCommand, Result>
{
    public async Task<Result> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Order? order = await orderRepository.GetByIdAsync(request.Id, cancellationToken);
        if (order == null)
        {
            logger.LogWarning("Order with ID {OrderId} not found", request.Id);
            return Result.NotFound($"Order with id {request.Id} not found");
        }

        order.CourseId = request.CourseId;
        order.OrderStatus = request.OrderStatus;
        orderRepository.Update(order);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
