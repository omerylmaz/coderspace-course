using Library.Application.Result;
using Library.Domain.Pagination;
using MediatR;

namespace Library.Application.Features.Books.Queries.GetPagedBooks;

public readonly record struct GetPagedBooksQuery(int PageNumber, int PageSize) : IRequest<Result<GetPagedBooksResponse>>;

public record GetPagedBooksResponse(PagedResult<GetBookResponse> Books);

public readonly record struct GetBookResponse(
    Guid Id,
    string Name,
    string Category,
    string Author,
    int Pages,
    string Status,
    DateOnly PublishedDate,
    decimal Price
    );