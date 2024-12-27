using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using Final.Application.Abstractions.Repositories;
using MediatR;

namespace Final.Application.Features.Courses.Queries.GetCourseById;

internal class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Result<GetOrderByIdResponse>>
{
    private readonly IGenericRepository<Order> _orderRepository;

    public GetOrderByIdQueryHandler(IGenericRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Result<GetOrderByIdResponse>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id, cancellationToken);
        if (order == null)
            return Result<GetOrderByIdResponse>.NotFound($"Order with id {request.Id} not found");

        var response = new GetOrderByIdResponse(order.Id, order.UserId, order.CourseId, order.OrderDate);
        return Result<GetOrderByIdResponse>.Success(response);
    }
}
