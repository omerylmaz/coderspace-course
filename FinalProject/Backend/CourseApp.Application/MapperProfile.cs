using AutoMapper;
using CourseApp.Application.DTOs.Category;
using CourseApp.Application.DTOs.Course;
using CourseApp.Application.Features.Courses.Queries.GetPaginatedTeacherCourses;
using CourseApp.Application.Features.Orders.Commands.CreateOrder;
using CourseApp.Application.Features.Users.Commands.UpdateUser;
using CourseApp.Domain.Entities;
using CourseApp.Domain.Pagination;
using Final.Application.Features.Courses.Commands.CreateCourse;
using Final.Application.Features.Courses.Commands.UpdateCourse;
using Final.Application.Features.Courses.Queries.GetCourseById;
using Final.Application.Features.Courses.Queries.GetPaginatedCourses;
using Final.Application.Features.Users.Commands.SignupUser;

namespace Final.Application;

internal class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<SignupUserCommand, AppUser>();

        CreateMap<CreateCourseCommand, Course>();

        CreateMap<UpdateCourseCommand, Course>();

        CreateMap<Course, GetCourseByIdResponse>();

        CreateMap<Course, GetCourseResponseDto>()
            .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category.Name));

        CreateMap<PagedResult<Course>, PagedResult<GetCourseResponseDto>>()
            .ForMember(d => d.Items, o => o.MapFrom(s => s.Items));

        CreateMap<Category, GetCategoryResponseDto>();

        CreateMap<CreateOrderCommand, Order>();

        CreateMap<Order, GetOrderByIdResponse>()
            .ForMember(d => d.OrderDate, o => o.MapFrom(s => s.CreatedDate));

        CreateMap<Order, GetOrderResponse>();

        CreateMap<UpdateUserCommand, AppUser>();
    }
}
