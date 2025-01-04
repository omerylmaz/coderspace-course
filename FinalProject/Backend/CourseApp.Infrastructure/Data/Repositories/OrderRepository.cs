using CourseApp.Application.Abstractions.Repositories;
using CourseApp.Domain.Entities;
using CourseApp.Domain.Enums;
using CourseApp.Infrastructure.Repositories;
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

    public async Task<List<Order>> GetAllOrdersByUserId(Guid userId, CancellationToken cancellationToken)
    {
        return await _dbSet
            .Include(x => x.Course)
            .ThenInclude(x => x.Category)
            .Include(x => x.Payment)
            .Where(x => x.OrderStatus == OrderStasusses.Completed && x.UserId == userId)
            .OrderBy(x => x.Payment.PaymentDate)
            .ToListAsync(cancellationToken);
    }

    public async Task<Order?> GetOrderDetailWhereAsync(Expression<Func<Order, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _dbSet
            .Include(x => x.User)
            .Include(x => x.Course)
            .ThenInclude(x => x.Category)
            .Include(x => x.Payment)
            .Where(predicate)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
