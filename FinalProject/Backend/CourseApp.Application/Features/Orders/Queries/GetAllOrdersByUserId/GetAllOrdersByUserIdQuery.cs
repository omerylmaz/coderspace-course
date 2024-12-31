using CourseApp.Application.ResultDto;
using MediatR;

namespace CourseApp.Application.Features.Orders.Queries.GetAllOrdersByUserId;

public record GetAllOrdersByUserIdQuery(Guid UserId) : IRequest<Result<GetAllOrdersByUserIdResponse>>;

public record GetAllOrdersByUserIdResponse(List<GetOrderResponse> Orders);

public record GetOrderResponse(Guid Id, Guid UserId, string CourseName, decimal Price, string? ImageUrl, string CourseCategoryName, DateTime PaymentDate);