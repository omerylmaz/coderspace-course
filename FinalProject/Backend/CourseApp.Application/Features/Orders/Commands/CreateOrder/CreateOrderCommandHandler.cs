using AutoMapper;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using Final.Application.Abstractions.Repositories;
using MediatR;

namespace CourseApp.Application.Features.Orders.Commands.CreateOrder;

internal class CreateOrderCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IGenericRepository<Order> orderRepository) 
    : IRequestHandler<CreateOrderCommand, Result<CreateOrderResponse>>
{
    public async Task<Result<CreateOrderResponse>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = mapper.Map<Order>(request);

        await orderRepository.AddAsync(order, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        var response = new CreateOrderResponse(order.Id);
        return Result<CreateOrderResponse>.Success(response);
    }
}