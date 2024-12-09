using Library.Application.Result;
using MediatR;
using Library.Application.Result;

namespace Library.Application.Features.Books.Commands.DeleteBookById;

public readonly record struct DeleteBookByIdCommand
(
    Guid Id    
) : IRequest<Library.Application.Result.Result>;