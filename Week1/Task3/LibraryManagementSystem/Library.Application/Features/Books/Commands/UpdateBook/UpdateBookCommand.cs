using Library.Domain.Enums;
using MediatR;

namespace Library.Application.Features.Books.Commands.UpdateBook;

public readonly record struct UpdateBookCommand
(
    Guid Id,
    string Name,
    string Category, 
    string Author, 
    int Pages, 
    BookStatus BookStatus, 
    DateOnly PublishedDate, 
    decimal Price
) : IRequest<Library.Application.Result.Result>;