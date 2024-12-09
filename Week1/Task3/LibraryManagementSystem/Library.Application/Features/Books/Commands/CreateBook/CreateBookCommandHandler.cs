using AutoMapper;
using Library.Application.Abstractions.Repositories;
using Library.Application.Abstractions.Services;
using Library.Application.Features.Books.Errors;
using Library.Application.Features.Books.Queries.GetBookById;
using Library.Application.Result;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Features.Books.Commands.CreateBook;

internal class CreateBookCommandHandler(IMapper mapper, IBookRepository bookRepository, IUnitOfWork unitOfWork, ICacheService cacheService) : IRequestHandler<CreateBookCommand, Result<CreateBookResponse>>
{
    public async Task<Result<CreateBookResponse>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        Book bookDomain = mapper.Map<Book>(request);
        bookDomain.Status = Domain.Enums.BookStatus.Available;

        bool isExists = await bookRepository.IsExistsAsync(x => x.Name.Equals(request.Name), cancellationToken);
        
        if (isExists)
            return Result<CreateBookResponse>.Failure(BookErrors.Conflict(request.Name));

        bookRepository.CreateBook(bookDomain);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        await cacheService.RemoveByPatternAsync(Constants.BOOKS_PAGED, cancellationToken);

        return Result<CreateBookResponse>.Success(new CreateBookResponse(bookDomain.Id));
    }
}
