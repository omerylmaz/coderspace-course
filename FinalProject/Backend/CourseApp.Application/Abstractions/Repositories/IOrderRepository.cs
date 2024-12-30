using CourseApp.Domain.Entities;
using Final.Application.Abstractions.Repositories;
using System.Linq.Expressions;

namespace CourseApp.Application.Abstractions.Repositories;

public interface IOrderRepository : IGenericRepository<Order>
{
    Task<Order?> GetOrderDetailWhereAsync(Expression<Func<Order, bool>> predicate, CancellationToken cancellationToken);
}