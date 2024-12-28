using AutoMapper;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using Final.Application.Abstractions.Repositories;
using MediatR;

namespace Final.Application.Features.Courses.Queries.GetCourseById;

internal class GetOrderByIdQueryHandler(IGenericRepository<Order> orderRepository, IMapper mapper) 
    : IRequestHandler<GetOrderByIdQuery, Result<GetOrderByIdResponse>>
{
    public async Task<Result<GetOrderByIdResponse>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetByIdAsync(request.Id, cancellationToken);
        if (order == null)
            return Result<GetOrderByIdResponse>.NotFound($"Order with id {request.Id} not found");

        var response = mapper.Map<GetOrderByIdResponse>(order);//new GetOrderByIdResponse(order.Id, order.UserId, order.CourseId, order.OrderDate);
        return Result<GetOrderByIdResponse>.Success(response);
    }
}
