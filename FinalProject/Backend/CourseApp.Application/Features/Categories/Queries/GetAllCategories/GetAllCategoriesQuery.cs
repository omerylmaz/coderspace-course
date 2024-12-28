using CourseApp.Application.DTOs.Category;
using CourseApp.Application.ResultDto;
using MediatR;

namespace CourseApp.Application.Features.Categories.Queries.GetAllCategories;

public record GetAllCategoriesQuery() : IRequest<Result<GetAllCategoriesResponse>>;


public record GetAllCategoriesResponse(List<GetCategoryResponseDto> Categories);