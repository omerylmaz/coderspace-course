using CourseApp.Application.Abstractions.Repositories;
using CourseApp.Domain.Entities;
using Final.Application.Abstractions.Repositories;
using Final.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CourseApp.Infrastructure.Data.Repositories;

internal class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    private readonly DbSet<Order> _dbSet;
    public OrderRepository(AppDbContext context) : base(context)
    {
        _dbSet = context.Set<Order>();
    }
    public async Task<Order?> GetOrderDetailWhereAsync(Expression<Func<Order, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _dbSet
            .Include(x => x.User)
            .Include(x => x.Course)
            .Include(x => x.Payment)
            .Where(predicate)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
