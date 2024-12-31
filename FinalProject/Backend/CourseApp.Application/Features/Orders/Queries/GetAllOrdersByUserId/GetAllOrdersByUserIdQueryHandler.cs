using AutoMapper;
using CourseApp.Application.Abstractions.Repositories;
using CourseApp.Application.Features.Orders.Queries.GetAllOrdersByUserId;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using CourseApp.Domain.Pagination;
using Final.Application.Abstractions.Repositories;
using MediatR;

namespace Final.Application.Features.Courses.Queries.GetPaginatedCourses;

internal class GetAllOrdersByUserIdQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    : IRequestHandler<GetAllOrdersByUserIdQuery, Result<GetAllOrdersByUserIdResponse>>
{
    public async Task<Result<GetAllOrdersByUserIdResponse>> Handle(GetAllOrdersByUserIdQuery request, CancellationToken cancellationToken)
    {
        List<Order> orders = await orderRepository.GetAllOrdersByUserId(request.UserId, cancellationToken);

        //var orderResponses = mapper.Map<List<GetOrderResponse>>(orders);
        var orderResponses = orders.Select(x => new GetOrderResponse
        (
            x.Id, x.UserId, x.Course.Name, x.Course.Price, x.Course.ImageUrl, x.Course.Category.Name, x.Payment.PaymentDate
            )).ToList();
        //{
        //    UserId = x.UserId,
        //    CourseCategoryName = x.Course.Category.Name,
        //    CourseName = x.Course.Name,
        //    Id = x.Id,
        //    ImageUrl = x.Course.ImageUrl,
        //    PaymentDate = x.Payment.PaymentDate,
        //    Price = x.Course.Price
        //});

        var response = new GetAllOrdersByUserIdResponse(orderResponses);
        return Result<GetAllOrdersByUserIdResponse>.Success(response);
    }
}