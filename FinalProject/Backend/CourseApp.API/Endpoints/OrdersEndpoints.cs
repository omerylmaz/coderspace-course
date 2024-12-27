using Carter;
using CourseApp.Application.Features.Orders.Commands.CreateOrder;
using CourseApp.Application.Features.Orders.Commands.DeleteOrderById;
using CourseApp.Application.Features.Orders.Commands.UpdateOrder;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Enums;
using Final.Application.Features.Courses.Queries.GetCourseById;
using Final.Application.Features.Courses.Queries.GetPaginatedCourses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Final.API.Endpoints;

public class OrdersEndpoints : CarterModule
{
    public OrdersEndpoints()
        : base("/api/orders")
    {
        WithTags("Orders");
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("", async (
            [FromBody] CreateOrderCommand command,
            [FromServices] IMediator mediator,
            ClaimsPrincipal user,
            CancellationToken cancellationToken) =>
        {
            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Results.Unauthorized();

            var userId = Guid.Parse(userIdClaim.Value);

            var request = command with { UserId = userId };

            var result = await mediator.Send(request, cancellationToken);

            if (!result.IsSuccess)
                return Results.Problem(result.ProblemDetails);

            return Results.Created($"/user/orders/{result.Data.Id}", result.Data);
        })
        .RequireAuthorization(new AuthorizeAttribute { Roles = $"{UserRoles.User}, {UserRoles.Teacher}" });

        app.MapGet("/{id}", async (
            [FromRoute] Guid id,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            Result<GetOrderByIdResponse> serviceResponse = await mediator.Send(new GetOrderByIdQuery(id), cancellationToken);

            if (!serviceResponse.IsSuccess)
                return Results.Problem(serviceResponse.ProblemDetails);

            return Results.Ok(serviceResponse);
        })
        .RequireAuthorization(new AuthorizeAttribute { Roles = $"{UserRoles.Teacher}, {UserRoles.User}" });

        app.MapGet("", async (
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            [FromServices] IMediator mediator,
            ClaimsPrincipal user,
            CancellationToken cancellationToken) =>
        {
            pageNumber = pageNumber > 0 ? pageNumber : 1;
            pageSize = pageSize > 0 ? pageSize : 10;
            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Results.Unauthorized();

            var userId = Guid.Parse(userIdClaim.Value);
            Result<GetPaginatedOrdersResponse> serviceResponse = await mediator.Send(new GetPaginatedOrdersQuery(userId, pageNumber, pageSize), cancellationToken);

            if (!serviceResponse.IsSuccess)
                return Results.Problem(serviceResponse.ProblemDetails);

            return Results.Ok(serviceResponse);
        })
        .RequireAuthorization(new AuthorizeAttribute { Roles = $"{UserRoles.Teacher}, {UserRoles.User}" });

        app.MapPut("", async (
            [FromBody] UpdateOrderCommand command,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            Result serviceResponse = await mediator.Send(command, cancellationToken);

            if (!serviceResponse.IsSuccess)
                return Results.Problem(serviceResponse.ProblemDetails);

            return Results.NoContent();
        })
        .RequireAuthorization(new AuthorizeAttribute { Roles = UserRoles.Admin.ToString() });

        app.MapDelete("/{id}", async (
            [FromRoute] Guid id,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            Result serviceResponse = await mediator.Send(new DeleteOrderByIdCommand(id), cancellationToken);

            if (!serviceResponse.IsSuccess)
                return Results.Problem(serviceResponse.ProblemDetails);

            return Results.NoContent();
        })
        .RequireAuthorization(new AuthorizeAttribute { Roles = UserRoles.Admin.ToString() });
    }
}
