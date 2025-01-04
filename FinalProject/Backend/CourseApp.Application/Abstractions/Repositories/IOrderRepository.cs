using CourseApp.Domain.Entities;
using System.Linq.Expressions;

namespace CourseApp.Application.Abstractions.Repositories;

public interface IOrderRepository : IGenericRepository<Order>
{
    Task<Order?> GetOrderDetailWhereAsync(Expression<Func<Order, bool>> predicate, CancellationToken cancellationToken);
    Task<List<Order>> GetAllOrdersByUserId(Guid userId, CancellationToken cancellationToken);
}