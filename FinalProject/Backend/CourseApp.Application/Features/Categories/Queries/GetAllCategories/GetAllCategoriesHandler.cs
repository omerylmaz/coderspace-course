using AutoMapper;
using CourseApp.Application.DTOs.Category;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using Final.Application.Abstractions.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Application.Features.Categories.Queries.GetAllCategories;

internal class GetAllCategoriesHandler(IGenericRepository<Category> categoryRepository, IMapper mapper) : IRequestHandler<GetAllCategoriesQuery, Result<GetAllCategoriesResponse>>
{
    public async Task<Result<GetAllCategoriesResponse>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await categoryRepository.GetAllAsync(cancellationToken);

        var categoryResponses = mapper.Map<List<GetCategoryResponseDto>>(categories);

        return Result<GetAllCategoriesResponse>.Success(new GetAllCategoriesResponse(categoryResponses));
    }
}
