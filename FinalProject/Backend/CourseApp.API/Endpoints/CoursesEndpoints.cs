using Carter;
using CourseApp.Application.Features.Courses.Queries.GetPaginatedCoursesByCategory;
using CourseApp.Application.Features.Courses.Queries.GetPaginatedCoursesByFiltering;
using CourseApp.Application.Features.Courses.Queries.GetPaidCoursesByUserId;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Enums;
using Final.Application;
using Final.Application.Features.Courses.Commands.CreateCourse;
using Final.Application.Features.Courses.Commands.DeleteCourseById;
using Final.Application.Features.Courses.Commands.UpdateCourse;
using Final.Application.Features.Courses.Queries.GetCourseById;
using Final.Application.Features.Courses.Queries.GetPaginatedCourses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading;

namespace Final.API.Endpoints;

public class CoursesEndpoints : CarterModule
{
    public CoursesEndpoints()
        : base("/api/courses")
    {
        WithTags("Courses");
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("", async (
            [FromBody] CreateCourseCommand command,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            Result<CreateCourseResponse> serviceResponse = await mediator.Send(command, cancellationToken);

            if (!serviceResponse.IsSuccess)
                return Results.Problem(serviceResponse.ProblemDetails);

            return Results.Created($"/{serviceResponse.Data.Id}", serviceResponse.Data);
        })
        .RequireAuthorization(new AuthorizeAttribute { Roles = UserRoles.Teacher.ToString() });

        app.MapGet("/{id}", async (
            [FromRoute] Guid id,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            Result<GetCourseByIdResponse> serviceResponse = await mediator.Send(new GetCourseByIdQuery(id), cancellationToken);

            if (!serviceResponse.IsSuccess)
                return Results.Problem(serviceResponse.ProblemDetails);

            return Results.Ok(serviceResponse);
        })
        .AllowAnonymous();

        app.MapGet("", async (
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            pageNumber = pageNumber > 0 ? pageNumber : 1;
            pageSize = pageSize > 0 ? pageSize : 10;

            Result<GetPaginatedCoursesResponse> serviceResponse = await mediator.Send(new GetPaginatedCoursesQuery(pageNumber, pageSize), cancellationToken);

            if (!serviceResponse.IsSuccess)
                return Results.Problem(serviceResponse.ProblemDetails);

            return Results.Ok(serviceResponse);
        })
        .AllowAnonymous();

        app.MapPut("", async (
            [FromBody] UpdateCourseCommand command,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            Result serviceResponse = await mediator.Send(command, cancellationToken);

            if (!serviceResponse.IsSuccess)
                return Results.Problem(serviceResponse.ProblemDetails);

            return Results.NoContent();
        })
        .RequireAuthorization(new AuthorizeAttribute { Roles = UserRoles.Teacher.ToString() });


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
        .RequireAuthorization(new AuthorizeAttribute { Roles = UserRoles.Teacher.ToString() });

        app.MapGet("/categories", async (
            [FromQuery] string[] categoryNames,
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            pageNumber = pageNumber > 0 ? pageNumber : 1;
            pageSize = pageSize > 0 ? pageSize : 10;

            var query = new GetPaginatedCoursesByCategoryQuery(pageNumber, pageSize, [.. categoryNames]);

            Result<GetPaginatedCoursesByCategoryResponse> serviceResponse = await mediator.Send(query, cancellationToken);

            if (!serviceResponse.IsSuccess)
                return Results.Problem(serviceResponse.ProblemDetails);

            return Results.Ok(serviceResponse);
        })
        .AllowAnonymous();

        app.MapGet("/filtering", async (
            [FromQuery] string? name,
            [FromQuery] string? title,
            [FromQuery] string? description,
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var query = new GetPaginatedCoursesByFilteringQuery
            {
                Name = name,
                Title = title,
                Description = description,
                PageNumber = pageNumber > 1 ? pageNumber : 1,
                PageSize = pageSize > 0 ? pageSize : 10,
            };

            Result<GetPaginatedCoursesByFilteringResponse> serviceResponse = await mediator.Send(query, cancellationToken);

            if (!serviceResponse.IsSuccess)
                return Results.Problem(serviceResponse.ProblemDetails);

            return Results.Ok(serviceResponse);
        })
        .AllowAnonymous();


        app.MapGet("/user/paid-courses", async (
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

            var query = new GetPaidCoursesByUserIdQuery(userId, pageNumber, pageSize);

            var result = await mediator.Send(query, cancellationToken);

            if (!result.IsSuccess)
                return Results.Problem(result.ProblemDetails);

            return Results.Ok(result.Data);
        })
        .RequireAuthorization(new AuthorizeAttribute { Roles = $"{UserRoles.User}, {UserRoles.Teacher}" });

    }
}
