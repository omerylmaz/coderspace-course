using Carter;
using CourseApp.API.Helpers;
using CourseApp.Application.Features.Orders.Commands.CompleteOrder;
using CourseApp.Application.Features.Payments.Commands.CreatePayment;
using CourseApp.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CourseApp.API.Endpoints;

public class PaymentsEndpoints : CarterModule
{
    public PaymentsEndpoints()
    : base("/api/payments")
    {
        WithTags("Payments");
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("", async (
            [FromBody] CreatePaymentCommand command,
            [FromServices] IMediator mediator,
            ClaimsPrincipal user,
            CancellationToken cancellationToken) =>
        {
            var userId = ClaimHelper.GetUserId(user);

            var request = command with { UserID = userId };

            var serviceResponse = await mediator.Send(request, cancellationToken);

            if (!serviceResponse.IsSuccess)
                return Results.Problem(serviceResponse.ProblemDetails);

            return Results.Ok(serviceResponse);
        })
        .RequireAuthorization(new AuthorizeAttribute { Roles = $"{UserRoles.User}, {UserRoles.Teacher}" });


        app.MapPost("PayCallBack", async (
            HttpRequest request, IMediator mediator ,CancellationToken cancellationToken) =>
        {
            var form = await request.ReadFormAsync(cancellationToken);

            var callbackData = new CompleteOrderCommand(
                Status: form["Status"],
                PaymentId: form["PaymentId"],
                ConversationData: form["ConversationData"],
                MDStatus: form["MDStatus"],
                ConversationId: form["ConversationId"]
            );

            var response = await mediator.Send(callbackData, cancellationToken);

            if (!response.IsSuccess)
                return Results.Conflict(response.ProblemDetails.Detail);

            return Results.Ok("Payment completed successfully");
        });

    }
}
