using AutoMapper;
using CourseApp.Application.Abstractions.Repositories;
using CourseApp.Application.Abstractions.Services;
using CourseApp.Application.DTOs.Category;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using MediatR;
using System.Reflection.Metadata;

namespace CourseApp.Application.Features.Categories.Queries.GetAllCategories;

internal class GetAllCategoriesHandler(IGenericRepository<Category> categoryRepository, IMapper mapper, ICacheService cacheService)
    : IRequestHandler<GetAllCategoriesQuery, Result<GetAllCategoriesResponse>>
{
    public async Task<Result<GetAllCategoriesResponse>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var cachedCategories = await cacheService.GetAsync<List<GetCategoryResponseDto>>(Constants.CacheKeys.CATEGORIES, cancellationToken);

        if (cachedCategories != null)
            return Result<GetAllCategoriesResponse>.Success(new GetAllCategoriesResponse(cachedCategories));

        var categories = await categoryRepository.GetAllAsync(cancellationToken);

        var categoryResponses = mapper.Map<List<GetCategoryResponseDto>>(categories);

        await cacheService.SetAsync(Constants.CacheKeys.CATEGORIES, categoryResponses, cancellationToken, TimeSpan.FromMinutes(10));

        return Result<GetAllCategoriesResponse>.Success(new GetAllCategoriesResponse(categoryResponses));
    }
}
