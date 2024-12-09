using Library.Application.Result;
using MediatR;

namespace Library.Application.Features.Books.Queries.GetBookById;

public readonly record struct GetBookByIdQuery(Guid Id) : IRequest<Result<GetBookByIdResponse>>;

public readonly record struct GetBookByIdResponse
    (
        Guid Id,
        string Name,
        string Category,
        string Author,
        int Pages,
        string Status,
        DateOnly PublishedDate,
        decimal Price
    );