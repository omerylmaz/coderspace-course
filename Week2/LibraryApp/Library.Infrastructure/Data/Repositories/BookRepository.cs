using Library.Application.Abstractions.Repositories;
using Library.Domain.Entities;
using Library.Domain.Pagination;
using Library.Infrastructure.Pagination;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Library.Infrastructure.Data.Repositories;

internal class BookRepository(AppDbContext dbContext) : IBookRepository
{
    public void CreateBook(Book book)
    {
        dbContext.Books.Add(book);
    }

    public void DeleteBook(Book book)
    {
        dbContext.Books.Remove(book);
    }

    public async Task<Book?> GetBookByFilterAsync(Expression<Func<Book, bool>> predicate, CancellationToken cancellationToken)
    {
        return await dbContext.Books.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<Book?> GetBookByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Set<Book>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<PagedResult<Book>> GetPagedBooksAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        IQueryable<Book> booksQuery = dbContext.Books.AsQueryable();
       
        PagedResult<Book> books = await Paginator.Paginate(booksQuery, pageNumber, pageSize);

        return books;
    }

    public async Task<bool> IsExistsAsync(Expression<Func<Book, bool>> predicate, CancellationToken cancellationToken)
    {
        return await dbContext.Set<Book>().AnyAsync(predicate, cancellationToken);
    }

    public void UpdateBook(Book book)
    {
        dbContext.Books.Update(book);
    }
}