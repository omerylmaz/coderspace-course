using CourseApp.Application.DTOs.Course;
using CourseApp.Application.Features.Courses.Queries.GetPaginatedCoursesByCategory;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace CourseApp.Application.Features.Courses.Queries.GetPaginatedCoursesByFiltering;

public record GetPaginatedCoursesByFilteringQuery : IRequest<Result<GetPaginatedCoursesByFilteringResponse>>
{
    public string? Name { get; init; }

    public string? Title { get; init; }

    public string? CategoryName { get; init; }

    public string? Description { get; init; }

    public int PageNumber { get; init; }

    public int PageSize { get; init; }
}


public record GetPaginatedCoursesByFilteringResponse(PagedResult<GetCourseResponseDto> Courses);