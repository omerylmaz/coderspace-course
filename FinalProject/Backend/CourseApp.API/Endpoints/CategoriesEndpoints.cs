using Carter;
using CourseApp.Application.Features.Categories.Queries.GetAllCategories;
using CourseApp.Application.ResultDto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.API.Endpoints;

public class CategoriesEndpoints : CarterModule
{
    public CategoriesEndpoints()
    : base("/api/categories")
    {
        WithTags("Categories");
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("", async (
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            Result<GetAllCategoriesResponse> serviceResponse = await mediator.Send(new GetAllCategoriesQuery(), cancellationToken);

            if (!serviceResponse.IsSuccess)
                return Results.Problem(serviceResponse.ProblemDetails);

            return Results.Ok(serviceResponse);
        })
        .AllowAnonymous();
    }
}
