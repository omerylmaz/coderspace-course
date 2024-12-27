using AutoMapper;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using Final.Application.Abstractions.Repositories;
using MediatR;

namespace CourseApp.Application.Features.Orders.Commands.CreateOrder;

internal class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<CreateOrderResponse>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericRepository<Order> _orderRepository;

    public CreateOrderCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IGenericRepository<Order> orderRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _orderRepository = orderRepository;
    }

    public async Task<Result<CreateOrderResponse>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            UserId = request.UserId,
            CourseId = request.CourseId,
            OrderDate = DateTime.UtcNow
        };

        await _orderRepository.AddAsync(order, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var response = new CreateOrderResponse(order.Id);
        return Result<CreateOrderResponse>.Success(response);
    }
}