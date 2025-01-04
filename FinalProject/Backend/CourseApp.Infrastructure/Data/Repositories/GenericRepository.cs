using CourseApp.Application.Abstractions.Repositories;
using CourseApp.Domain.Entities;
using CourseApp.Domain.Pagination;
using CourseApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CourseApp.Infrastructure.Repositories;

internal class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(AppDbContext context)
    {
        _dbSet = context.Set<TEntity>();
    }

    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbSet.FindAsync(id, cancellationToken);
    }

    public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }

    public async Task<PagedResult<TEntity>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var totalCount = await _dbSet.CountAsync(cancellationToken);
        var items = await _dbSet.Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync(cancellationToken);
        return new PagedResult<TEntity>(items, pageNumber, pageSize, totalCount);
    }

    public async Task<PagedResult<TEntity>> GetPagedWhereAsync(Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var query = _dbSet.Where(predicate);

        var totalCount = await query.CountAsync(cancellationToken);
        var items = await query.Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync(cancellationToken);

        return new PagedResult<TEntity>(items, pageNumber, pageSize, totalCount);
    }

    public async Task<List<TEntity>> GetAllWhereAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _dbSet.Where(predicate).ToListAsync(cancellationToken);
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _dbSet.AnyAsync(predicate, cancellationToken);
    }


    public async Task<TEntity?> GetWhereAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _dbSet.CountAsync(predicate, cancellationToken);
    }
}
