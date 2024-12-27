using CourseApp.Application.Abstractions.Repositories;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using Final.Application.Abstractions.Repositories;
using Final.Application.Abstractions.Repositories;
using MediatR;

namespace CourseApp.Application.Features.Orders.Commands.DeleteOrderById;

internal class DeleteOrderByIdCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteOrderByIdCommand, Result>
{
    public async Task<Result> Handle(DeleteOrderByIdCommand request, CancellationToken cancellationToken)
    {
        Order order = await orderRepository.GetByIdAsync(request.Id, cancellationToken);

        if (order == null)
            return Result.NotFound($"{request.Id} id not found");

        orderRepository.Delete(order);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
