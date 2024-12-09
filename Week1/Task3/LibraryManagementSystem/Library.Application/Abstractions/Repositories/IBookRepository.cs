using Library.Domain.Entities;
using Library.Domain.Pagination;
using System.Linq.Expressions;

namespace Library.Application.Abstractions.Repositories;

public interface IBookRepository
{
    void CreateBook(Book book);
    void DeleteBook(Book book);
    Task<Book> GetBookByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<PagedResult<Book>> GetPagedBooksAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
    void UpdateBook(Book book);
    Task<Book?> GetBookByFilterAsync(Expression<Func<Book, bool>> predicate, CancellationToken cancellationToken);
    Task<bool> IsExistsAsync(Expression<Func<Book, bool>> predicate, CancellationToken cancellationToken);
}
