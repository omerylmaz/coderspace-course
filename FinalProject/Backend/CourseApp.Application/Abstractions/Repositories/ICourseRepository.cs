using CourseApp.Application.Features.Courses.Queries.GetPaginatedCoursesByFiltering;
using CourseApp.Domain.Entities;
using CourseApp.Domain.Pagination;

namespace Final.Application.Abstractions.Repositories;

public interface ICourseRepository : IGenericRepository<Course>
{
    Task<PagedResult<Course>> GetPagedWithCategoryNameAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task<Course?> GetByIdWithCategoryNameAsync(Guid id, CancellationToken cancellationToken);
    Task<PagedResult<Course>> GetPagedByCategoryNamesAsync(List<string> categoryNames, int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task<PagedResult<Course>> GetPaidCoursesByUserIdAsync(Guid userId, int pageNumber, int pageSize, CancellationToken cancellationToken);
    public Task<PagedResult<Course>> GetPagedCoursesByFilteringAsync(
        string? name,
        string? title,
        string? categoryName,
        string? description,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken);
}