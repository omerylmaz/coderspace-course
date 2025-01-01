using CourseApp.Domain.Entities;
using CourseApp.Domain.Pagination;
using Final.Application.Abstractions.Repositories;
using System.Linq.Expressions;

namespace CourseApp.Application.Abstractions.Repositories;

public interface INotificationRepository : IGenericRepository<Notification>
{
    Task<PagedResult<Notification>> GetPagedByOrder(Expression<Func<Notification, bool>> predicate, int pageNumber, int pageSize, CancellationToken cancellationToken);
}