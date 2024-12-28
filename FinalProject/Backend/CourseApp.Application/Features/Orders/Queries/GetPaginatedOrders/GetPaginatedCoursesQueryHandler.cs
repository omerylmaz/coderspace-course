using AutoMapper;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using CourseApp.Domain.Pagination;
using Final.Application.Abstractions.Repositories;
using MediatR;

namespace Final.Application.Features.Courses.Queries.GetPaginatedCourses;

internal class GetPaginatedOrdersQueryHandler(IGenericRepository<Order> orderRepository, IMapper mapper) 
    : IRequestHandler<GetPaginatedOrdersQuery, Result<GetPaginatedOrdersResponse>>
{
    public async Task<Result<GetPaginatedOrdersResponse>> Handle(GetPaginatedOrdersQuery request, CancellationToken cancellationToken)
    {
        PagedResult<Order> pagedOrders = await orderRepository.GetPagedWhereAsync(x => x.UserId == request.UserId ,request.PageNumber, request.PageSize, cancellationToken);

        var orderResponses = mapper.Map<PagedResult<GetOrderResponse>>(pagedOrders);
        var response = new GetPaginatedOrdersResponse(orderResponses);
        return Result<GetPaginatedOrdersResponse>.Success(response);
    }
}