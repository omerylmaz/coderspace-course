using Carter;
using CourseApp.API.Helpers;
using CourseApp.Application.Features.Notifications.Commands.MarkAsRead;
using CourseApp.Application.Features.Notifications.Queries.GetPaginatedNotifications;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CourseApp.API.Endpoints;

public class NotificationsEndpoints : CarterModule
{
    public NotificationsEndpoints()
    : base("/api/notifications")
    {
        WithTags("Notifications");
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("", async (
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken,
            ClaimsPrincipal user) =>
        {
            var userId = ClaimHelper.GetUserId(user);

            Result<GetPaginatedNotificationsResponse> serviceResponse = await mediator.Send(new GetPaginatedNotificationsQuery { UserId = userId, PageNumber = pageNumber, PageSize = pageSize}, cancellationToken);

            if (!serviceResponse.IsSuccess)
                return Results.Problem(serviceResponse.ProblemDetails);

            return Results.Ok(serviceResponse);
        })
        .RequireAuthorization(new AuthorizeAttribute { Roles = $"{UserRoles.User}, {UserRoles.Teacher}" });

        app.MapPatch("/mark-as-read/{id}", async (
            [FromRoute] Guid id,
            [FromServices] IMediator mediator,
            ClaimsPrincipal user,
            CancellationToken cancellationToken) =>
        {
            var userId = ClaimHelper.GetUserId(user);

            Result serviceResponse = await mediator.Send(new MarkAsReadCommand { NotificationId = id, UserId = userId }, cancellationToken);

            if (!serviceResponse.IsSuccess)
                return Results.Problem(serviceResponse.ProblemDetails);

            return Results.NoContent();
        })
        .RequireAuthorization(new AuthorizeAttribute { Roles = $"{UserRoles.User}, {UserRoles.Teacher}" });
    }
}
