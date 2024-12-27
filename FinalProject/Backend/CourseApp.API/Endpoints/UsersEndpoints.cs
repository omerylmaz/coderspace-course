using Carter;
using CourseApp.Application.Features.Courses.Queries.GetPaidCoursesByUserId;
using CourseApp.Application.Features.Users.Commands.CreateTokenByRefreshToken;
using CourseApp.Application.ResultDto;
using Final.Application.Features.Users.Commands.LoginUser;
using Final.Application.Features.Users.Commands.SignupUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Final.API.Endpoints;

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
    }
}
