using AutoMapper;
using Library.Application.Abstractions.Repositories;
using Library.Application.Features.Books.Errors;
using Library.Application.Result;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Features.Books.Queries.GetBookById;

internal class GetBookByIdQueryHandler(IMapper mapper, IBookRepository bookRepository) : IRequestHandler<GetBookByIdQuery, Result<GetBookByIdResponse>>
{
    public async Task<Result<GetBookByIdResponse>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        Book bookDomain = await bookRepository.GetBookByIdAsync(request.Id, cancellationToken);
        if (bookDomain == null)
            return Result<GetBookByIdResponse>.Failure(BookErrors.NotFound(request.Id.ToString()));

        GetBookByIdResponse bookResponse = mapper.Map<GetBookByIdResponse>(bookDomain);
        return Result<GetBookByIdResponse>.Success(bookResponse);
    }
}
