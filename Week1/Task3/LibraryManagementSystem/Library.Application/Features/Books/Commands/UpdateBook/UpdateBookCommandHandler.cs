using AutoMapper;
using Library.Application.Abstractions.Repositories;
using Library.Application.Abstractions.Services;
using Library.Application.Features.Books.Errors;
using Library.Application.Features.Books.Queries.GetBookById;
using Library.Application.Result;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Features.Books.Commands.UpdateBook;

internal class UpdateBookCommandHandler(IMapper mapper, IBookRepository bookRepository, IUnitOfWork unitOfWork, ICacheService cacheService) 
    : IRequestHandler<UpdateBookCommand, Library.Application.Result.Result>
{
    public async Task<Library.Application.Result.Result> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        Book bookDomain = await bookRepository.GetBookByIdAsync(request.Id, cancellationToken);

        if (bookDomain == null)
            return Result<GetBookByIdResponse>.Failure(BookErrors.NotFound(request.Id.ToString()));

        mapper.Map(request, bookDomain);
        bookRepository.UpdateBook(bookDomain);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        await cacheService.RemoveByPatternAsync(Constants.BOOKS_PAGED, cancellationToken);
        return Library.Application.Result.Result.Success();
    }
}
