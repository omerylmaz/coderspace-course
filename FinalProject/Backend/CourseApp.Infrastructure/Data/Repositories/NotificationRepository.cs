using CourseApp.Application.Abstractions.Repositories;
using CourseApp.Domain.Entities;
using CourseApp.Domain.Pagination;
using Final.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CourseApp.Infrastructure.Data.Repositories;

internal class NotificationRepository : GenericRepository<Notification>, INotificationRepository
{
    private readonly DbSet<Notification> _dbSet;
    public NotificationRepository(AppDbContext context) : base(context)
    {
        _dbSet = context.Set<Notification>();
    }

    public async Task<PagedResult<Notification>> GetPagedByOrder(Expression<Func<Notification, bool>> predicate, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var totalCount = await _dbSet.CountAsync(cancellationToken);

        var items = await _dbSet
            .Where(predicate)
            .OrderBy(n => n.IsRead)
            .ThenByDescending(n => n.CreatedDate)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PagedResult<Notification>(items, totalCount, pageNumber, pageSize);

    }
}