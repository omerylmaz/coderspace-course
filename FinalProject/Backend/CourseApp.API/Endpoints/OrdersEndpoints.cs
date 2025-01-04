using Carter;
using CourseApp.API.Helpers;
using CourseApp.Application.Features.Courses.Queries.GetCourseById;
using CourseApp.Application.Features.Orders.Commands.CreateOrder;
using CourseApp.Application.Features.Orders.Queries.GetAllOrdersByUserId;

using CourseApp.Application.ResultDto;
using CourseApp.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CourseApp.API.Endpoints;

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
            var userId = ClaimHelper.GetUserId(user);

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
            [FromServices] IMediator mediator,
            ClaimsPrincipal user,
            CancellationToken cancellationToken) =>
        {
            var userId = ClaimHelper.GetUserId(user);
            Result<GetAllOrdersByUserIdResponse> serviceResponse = await mediator.Send(new GetAllOrdersByUserIdQuery(userId), cancellationToken);

            if (!serviceResponse.IsSuccess)
                return Results.Problem(serviceResponse.ProblemDetails);

            return Results.Ok(serviceResponse);
        })
        .RequireAuthorization(new AuthorizeAttribute { Roles = $"{UserRoles.Teacher}, {UserRoles.User}" });

        //app.MapPut("", async (
        //    [FromBody] UpdateOrderCommand command,
        //    [FromServices] IMediator mediator,
        //    CancellationToken cancellationToken) =>
        //{
        //    Result serviceResponse = await mediator.Send(command, cancellationToken);

        //    if (!serviceResponse.IsSuccess)
        //        return Results.Problem(serviceResponse.ProblemDetails);

        //    return Results.NoContent();
        //})
        //.RequireAuthorization(new AuthorizeAttribute { Roles = UserRoles.Admin.ToString() });

        //app.MapDelete("/{id}", async (
        //    [FromRoute] Guid id,
        //    [FromServices] IMediator mediator,
        //    CancellationToken cancellationToken) =>
        //{
        //    Result serviceResponse = await mediator.Send(new DeleteOrderByIdCommand(id), cancellationToken);

        //    if (!serviceResponse.IsSuccess)
        //        return Results.Problem(serviceResponse.ProblemDetails);

        //    return Results.NoContent();
        //})
        //.RequireAuthorization(new AuthorizeAttribute { Roles = UserRoles.Admin.ToString() });
    }
}
