using Carter;
using Library.Application.Features.Books.Commands.CreateBook;
using Library.Application.Features.Books.Commands.DeleteBookById;
using Library.Application.Features.Books.Commands.UpdateBook;
using Library.Application.Features.Books.Queries.GetBookById;
using Library.Application.Features.Books.Queries.GetPagedBooks;
using Library.Application.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Endpoints;

// Burada minimal apiyi tercih ettim. Kütüphane olarak çok maliyete sebep vermediği için minimal api yapısı için Carter kütüphanesini kullandım.
// Hata yönetimi için Result pattern kullandım. Bilinmeyen hataları yakalamak için ise IExceptionHandler kullandım
public class BookEndpoints : CarterModule
{
    public BookEndpoints() 
        : base("/api/books")
    {
        WithTags("Books");
    }
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost((""), async 
            ([FromBody] CreateBookCommand command, 
            [FromServices] IMediator mediator, 
            CancellationToken cancellationToken) =>
        {
            Result<CreateBookResponse> serviceResponse = await mediator.Send(command, cancellationToken);

            if (!serviceResponse.IsSuccess)
                return Results.Problem(serviceResponse.ProblemDetails);

            return Results.Created($"/{serviceResponse.Value.Id}", serviceResponse.Value);
        });


        app.MapGet("/{id}", async (
            [FromRoute] Guid id,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            Result<GetBookByIdResponse> serviceResponse = await mediator.Send(new GetBookByIdQuery(id), cancellationToken);

            if (!serviceResponse.IsSuccess)
                return Results.Problem(serviceResponse.ProblemDetails);

            return Results.Ok(serviceResponse.Value);
        });


        app.MapGet((""), async (
            [FromQuery] int pageNumber, 
            [FromQuery] int pageSize, 
            [FromServices] IMediator mediator, 
            CancellationToken cancellationToken) =>
        {
            pageNumber = pageNumber > 0 ? pageNumber : 1;
            pageSize = pageSize > 0 ? pageSize : 10;
            Result<GetPagedBooksResponse> serviceResponse = await mediator.Send(new GetPagedBooksQuery(pageNumber, pageSize), cancellationToken);

            if (!serviceResponse.IsSuccess)
                return Results.Problem(serviceResponse.ProblemDetails);

            return Results.Ok(serviceResponse.Value);
        });


        app.MapDelete(("/{id}"), async (
            [FromRoute] Guid id,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            Library.Application.Result.Result serviceResponse = await mediator.Send(new DeleteBookByIdCommand(id), cancellationToken);
            if (!serviceResponse.IsSuccess)
                return Results.Problem(serviceResponse.ProblemDetails);

            return Results.NoContent();
        });


        app.MapPut((""), async (
            [FromBody] UpdateBookCommand command, 
            [FromServices] IMediator mediator, 
            CancellationToken cancellationToken) =>
        {
            Library.Application.Result.Result serviceResponse = await mediator.Send(command, cancellationToken);
            if (!serviceResponse.IsSuccess)
                return Results.Problem(serviceResponse.ProblemDetails);

            return Results.NoContent();
        });
    }
}
