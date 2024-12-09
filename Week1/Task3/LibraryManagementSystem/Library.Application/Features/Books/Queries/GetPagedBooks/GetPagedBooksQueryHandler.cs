using AutoMapper;
using Library.Application.Abstractions.Repositories;
using Library.Application.Abstractions.Services;
using Library.Application.Features.Books.Errors;
using Library.Application.Result;
using Library.Domain.Entities;
using Library.Domain.Pagination;
using MediatR;

namespace Library.Application.Features.Books.Queries.GetPagedBooks;

internal class GetPagedBooksQueryHandler(IMapper mapper, IBookRepository bookRepository, ICacheService cacheService) : IRequestHandler<GetPagedBooksQuery, Result<GetPagedBooksResponse>>
{
    public async Task<Result<GetPagedBooksResponse>> Handle(GetPagedBooksQuery request, CancellationToken cancellationToken)
    {
        string cacheKey = $"{Constants.BOOKS_PAGED}-{request.PageNumber}-{request.PageSize}";
        PagedResult<Book> pagedBooks = await cacheService.GetAsync<PagedResult<Book>>(cacheKey, cancellationToken);

        if (pagedBooks == null)
        {
            pagedBooks = await bookRepository.GetPagedBooksAsync(request.PageNumber, request.PageSize, cancellationToken);
            await cacheService.SetAsync<PagedResult<Book>>(cacheKey, pagedBooks, cancellationToken: cancellationToken);
        }

        if (!pagedBooks.Items.Any())
        {
            return Result<GetPagedBooksResponse>.Failure(BookErrors.NotFound());
        }
        
        PagedResult<GetBookResponse> pagedResult = mapper.Map<PagedResult<GetBookResponse>>(pagedBooks);
        return Result<GetPagedBooksResponse>.Success(new GetPagedBooksResponse(pagedResult));
    }
}
