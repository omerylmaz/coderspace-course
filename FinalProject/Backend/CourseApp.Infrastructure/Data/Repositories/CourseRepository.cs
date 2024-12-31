using CourseApp.Application.Features.Courses.Queries.GetPaginatedTeacherCourses;
using CourseApp.Domain.Entities;
using CourseApp.Domain.Enums;
using CourseApp.Domain.Pagination;
using CourseApp.Infrastructure.Data;
using Final.Application.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Final.Infrastructure.Repositories;

internal class CourseRepository : GenericRepository<Course>, ICourseRepository
{
    private readonly DbSet<Course> _dbSet;
    public CourseRepository(AppDbContext context) : base(context)
    {
        _dbSet = context.Set<Course>();
    }

    public Task<Course?> GetByIdWithCategoryNameAsync(Guid id, CancellationToken cancellationToken)
    {
        return _dbSet.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<PagedResult<Course>> GetPagedWithCategoryNameAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var totalCount = await _dbSet.CountAsync(cancellationToken);
        var items = await _dbSet
            .AsNoTracking()
            .Include(x => x.Category)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
        return new PagedResult<Course>(items, pageNumber, pageSize, totalCount);
    }

    public async Task<PagedResult<Course>> GetPagedByCategoryNamesAsync(List<string> categoryNames, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var totalCount = await _dbSet
            .AsNoTracking()
            .Include(x => x.Category)
            .Where(x => categoryNames.Contains(x.Category.Name))
            .CountAsync(cancellationToken);

        var items = await _dbSet
            .AsNoTracking()
            .Include(x => x.Category)
            .Where(x => categoryNames.Contains(x.Category.Name))
            .OrderBy(x => x.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PagedResult<Course>(items, pageNumber, pageSize, totalCount);
    }

    public async Task<PagedResult<Course>> GetPaidCoursesByUserIdAsync(Guid userId, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var totalCount = await _dbSet
            .AsNoTracking()
            .Where(x => x.Orders.Any(y => y.UserId == userId))
            .CountAsync(cancellationToken);

        var items = await _dbSet
            .AsNoTracking()
            .Include(x => x.Category)
            .Where(x => x.Orders.Any(y => y.UserId == userId))
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PagedResult<Course>(items, pageNumber, pageSize, totalCount);
    }

    public async Task<PagedResult<Course>> GetPagedCoursesByFilteringAsync(
        string? name,
        string? title,
        string? categoryName,
        string? description,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken)
    {
        var query = _dbSet
            .AsNoTracking()
            .Include(x => x.Category)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(name))
            query = query.Where(course => course.Name.Contains(name));

        if (!string.IsNullOrWhiteSpace(title))
            query = query.Where(course => course.Title.Contains(title));

        if (!string.IsNullOrWhiteSpace(categoryName))
            query = query.Where(course => course.Category.Name == categoryName);

        if (!string.IsNullOrWhiteSpace(description))
            query = query.Where(course => course.Description.Contains(description));

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PagedResult<Course>(items, pageNumber, pageSize, totalCount);
    }
}