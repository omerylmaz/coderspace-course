using Carter;
using CourseApp.API.Helpers;
using CourseApp.Application.Features.Users.Commands.ChangePassword;
using CourseApp.Application.Features.Users.Commands.CreateTokenByRefreshToken;
using CourseApp.Application.Features.Users.Commands.LoginUser;
using CourseApp.Application.Features.Users.Commands.SignupUser;
using CourseApp.Application.Features.Users.Commands.UpdateUser;
using CourseApp.Application.Features.Users.Queries.GetUserDetail;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CourseApp.API.Endpoints;

// Burada minimal apiyi tercih ettim. Kütüphane olarak çok maliyete sebep vermediği için minimal api yapısı için Carter kütüphanesini kullandım.
// Hata yönetimi için Result pattern kullandım. Bilinmeyen hataları yakalamak için ise IExceptionHandler kullandım
public class UsersEndpoints : CarterModule
{
    public UsersEndpoints()
        : base("/api/users")
    {
        WithTags("Users");
    }
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(("register"), async
            ([FromBody] SignupUserCommand command,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            Result<SignupUserResponse> serviceResponse = await mediator.Send(command, cancellationToken);

            if (!serviceResponse.IsSuccess)
                return Results.Problem(serviceResponse.ProblemDetails);

            return Results.Created($"/{serviceResponse.Data.Id}", serviceResponse.Data);
        });

        app.MapPost("login", async
            ([FromBody] LoginUserCommand command,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            Result<LoginUserResponse> serviceResponse = await mediator.Send(command, cancellationToken);

            if (!serviceResponse.IsSuccess)
                return Results.Problem(serviceResponse.ProblemDetails);

            return Results.Ok(serviceResponse);
        });


        app.MapPost("refresh-token", async
            ([FromBody] CreateTokenByRefreshTokenCommand command,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            Result<CreateTokenByRefreshTokenResponse> serviceResponse = await mediator.Send(command, cancellationToken);

            if (!serviceResponse.IsSuccess)
                return Results.Problem(serviceResponse.ProblemDetails);

            return Results.Ok(serviceResponse);
        });

        app.MapGet("detail", async
            (
            [FromServices] IMediator mediator,
            ClaimsPrincipal user,
            CancellationToken cancellationToken) =>
        {
            var userId = ClaimHelper.GetUserId(user);
            Result<GetUserDetailResponse> serviceResponse = await mediator.Send(new GetUserDetailQuery(userId), cancellationToken);

            if (!serviceResponse.IsSuccess)
                return Results.Problem(serviceResponse.ProblemDetails);

            return Results.Ok(serviceResponse);
        })
        .RequireAuthorization(new AuthorizeAttribute { Roles = $"{UserRoles.User}, {UserRoles.Teacher}" });

        app.MapPut("", async
        (
            [FromBody] UpdateUserCommand command,
            [FromServices] IMediator mediator,
            ClaimsPrincipal user,
            CancellationToken cancellationToken) =>
        {
            var userId = ClaimHelper.GetUserId(user);
            Result serviceResponse = await mediator.Send(command with { Id = userId }, cancellationToken);

            if (!serviceResponse.IsSuccess)
                return Results.Problem(serviceResponse.ProblemDetails);

            return Results.NoContent();
        })
        .RequireAuthorization(new AuthorizeAttribute { Roles = $"{UserRoles.User}, {UserRoles.Teacher}" });

        app.MapPatch("change-password", async
        (
            [FromBody] ChangePasswordCommand command,
            [FromServices] IMediator mediator,
            ClaimsPrincipal user,
            CancellationToken cancellationToken) =>
        {
            var userId = ClaimHelper.GetUserId(user);
            Result serviceResponse = await mediator.Send(command with { UserId = userId }, cancellationToken);

            if (!serviceResponse.IsSuccess)
                return Results.Problem(serviceResponse.ProblemDetails);

            return Results.NoContent();
        })
        .RequireAuthorization(new AuthorizeAttribute { Roles = $"{UserRoles.User}, {UserRoles.Teacher}" });
    }
}
