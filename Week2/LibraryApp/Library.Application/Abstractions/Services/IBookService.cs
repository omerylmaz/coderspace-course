using Library.Application.DTOs.Book;
using Library.Application.Result;

namespace Library.Application.Abstractions.Services;

public interface IBookService
{
    Task<Result<CreateBookResponseDto>> CreateBookAsync(CreateBookRequestDto request, CancellationToken cancellationToken);

    // Task<Result> DeleteBookByIdAsync(DeleteBookByIdRequest request, CancellationToken cancellationToken);
    // Task<Result> UpdateBookAsync(UpdateBookRequest request, CancellationToken cancellationToken);

    Task<Result<GetBookByIdResponseDto>> GetBookByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<Result<GetPagedBooksResponseDto>> GetPagedBooksAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
}