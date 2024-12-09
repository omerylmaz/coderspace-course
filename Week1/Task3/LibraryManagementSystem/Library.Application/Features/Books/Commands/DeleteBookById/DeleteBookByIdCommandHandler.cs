using Library.Application.Abstractions.Repositories;
using Library.Application.Abstractions.Services;
using Library.Application.Features.Books.Errors;
using Library.Application.Features.Books.Queries.GetBookById;
using Library.Application.Result;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Features.Books.Commands.DeleteBookById;

internal class DeleteBookByIdCommandHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork, ICacheService cacheService) : IRequestHandler<DeleteBookByIdCommand, Library.Application.Result.Result>
{
    public async Task<Library.Application.Result.Result> Handle(DeleteBookByIdCommand request, CancellationToken cancellationToken)
    {
        Book book = await bookRepository.GetBookByIdAsync(request.Id, cancellationToken);

        if (book == null)
            return Result<GetBookByIdResponse>.Failure(BookErrors.NotFound(request.Id.ToString()));

        bookRepository.DeleteBook(book);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        await cacheService.RemoveByPatternAsync(Constants.BOOKS_PAGED, cancellationToken);

        return Library.Application.Result.Result.Success();
    }
}
