using Library.Application.Result;
using MediatR;

namespace Library.Application.Features.Books.Commands.CreateBook;

public readonly record struct CreateBookCommand(
    string Name,
    string Category,
    string Author,
    int Pages,
    DateOnly PublishedDate,
    decimal Price
) : IRequest<Result<CreateBookResponse>>;

public readonly record struct CreateBookResponse(Guid Id);