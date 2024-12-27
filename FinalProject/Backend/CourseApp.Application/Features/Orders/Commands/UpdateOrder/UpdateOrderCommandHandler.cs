using AutoMapper;
using CourseApp.Application.Abstractions.Repositories;
using CourseApp.Application.ResultDto;
using Final.Application.Abstractions.Repositories;
using MediatR;

namespace CourseApp.Application.Features.Orders.Commands.UpdateOrder;

internal class UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<UpdateOrderCommand, Result>
{
    public async Task<Result> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetByIdAsync(request.Id, cancellationToken);
        if (order == null)
            return Result.NotFound($"Order with id {request.Id} not found");

        order.CourseId = request.CourseId;
        orderRepository.Update(order);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
