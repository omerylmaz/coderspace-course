using Carter;
using CourseApp.API.Helpers;
using CourseApp.Application.DTOs.Payment;
using CourseApp.Application.Features.Orders.Commands.CreateOrder;
using CourseApp.Application.Features.Payments.Commands.CreatePayment;
using CourseApp.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
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

            var result = await mediator.Send(request, cancellationToken);

            if (!result.IsSuccess)
                return Results.Problem(result.ProblemDetails);

            return Results.Ok(result.Data.htmlContent);
        })
        .RequireAuthorization(new AuthorizeAttribute { Roles = $"{UserRoles.User}, {UserRoles.Teacher}" });


        app.MapPost("PayCallBack", async (
            HttpRequest request, CancellationToken cancellationToken) =>
        {
            var form = await request.ReadFormAsync(cancellationToken);

            var callbackData = new PaymentCallbackData(
                Status: form["Status"],
                PaymentId: form["PaymentId"],
                ConversationData: form["ConversationData"],
                MDStatus: form["MDStatus"],
                ConversationId: long.TryParse(form["ConversationId"], out var id) ? id : 0
            );

            if (callbackData.Status != "success")
            {
                return Results.BadRequest("Payment Failed");
            }

            return Results.Ok("Payment happened successfully");
        });

    }
}
