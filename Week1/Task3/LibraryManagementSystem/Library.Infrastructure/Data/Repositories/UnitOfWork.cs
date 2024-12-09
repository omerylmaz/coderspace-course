using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Library.Application.Abstractions.Repositories;

namespace Library.Infrastructure.Data.Repositories;

internal class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;

    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        FillCreatedEntities();
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private void FillCreatedEntities()
    {
        var entries = _dbContext.ChangeTracker.Entries()
            .Where(e => e.Entity is BaseEntity && e.State == EntityState.Added);

        foreach (var entry in entries)
        {
            var entity = (BaseEntity)entry.Entity;
            entity.CreatedDate = DateTime.UtcNow;
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }
        }
    }
}
