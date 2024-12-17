using Library.Domain.Pagination;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Pagination;

public class Paginator
{
    public static async Task<PagedResult<T>> Paginate<T>(IQueryable<T> query, int pageNumber = 1, int pageSize = 10)
    {
        int totalCount = await query.CountAsync();
        var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return new PagedResult<T>(items, pageNumber, pageSize, totalCount);
    }

}
    