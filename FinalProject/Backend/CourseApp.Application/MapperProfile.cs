using AutoMapper;
using CourseApp.Application.DTOs.Category;
using CourseApp.Application.DTOs.Course;
using CourseApp.Application.Features.Courses.Commands.UpdateCourse;
using CourseApp.Application.Features.Courses.Queries.GetCourseById;
using CourseApp.Application.Features.Notifications.Queries.GetPaginatedNotifications;
using CourseApp.Application.Features.Orders.Commands.CreateOrder;
using CourseApp.Application.Features.Orders.Queries.GetAllOrdersByUserId;
using CourseApp.Application.Features.Users.Commands.SignupUser;
using CourseApp.Application.Features.Users.Commands.UpdateUser;
using CourseApp.Domain.Entities;
using CourseApp.Domain.Pagination;
using Final.Application.Features.Courses.Commands.CreateCourse;
using Final.Application.Features.Courses.Queries.GetCourseById;

namespace CourseApp.Application;

internal class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<SignupUserCommand, AppUser>();

        CreateMap<CreateCourseCommand, Course>();

        CreateMap<UpdateCourseCommand, Course>();

        CreateMap<Course, GetCourseByIdResponse>();

        CreateMap<Content, ContentResponse>();

        CreateMap<CreateCourseContentCommand, Content>();

        CreateMap<UpdateCourseContentCommand, Content>();

        CreateMap<Course, GetCourseResponseDto>()
            .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category.Name));

        CreateMap<PagedResult<Course>, PagedResult<GetCourseResponseDto>>()
            .ForMember(d => d.Items, o => o.MapFrom(s => s.Items));

        CreateMap<Category, GetCategoryResponseDto>();

        CreateMap<CreateOrderCommand, Order>();

        CreateMap<Order, GetOrderByIdResponse>()
            .ForMember(d => d.OrderDate, o => o.MapFrom(s => s.CreatedDate));

        //CreateMap<List<Order>, List<GetOrderResponse>>()
        //    .ForMember(d => d);

        CreateMap<Order, GetOrderResponse>()
            .ForMember(d => d.CourseCategoryName, o => o.MapFrom(s => s.Course.Category.Name))
            .ForMember(d => d.CourseName, o => o.MapFrom(s => s.Course.Name))
            .ForMember(d => d.ImageUrl, o => o.MapFrom(s => s.Course.ImageUrl))
            .ForMember(d => d.PaymentDate, o => o.MapFrom(s => s.Payment.PaymentDate))
            .ForMember(d => d.Price, o => o.MapFrom(s => s.Course.Price))
            .ForMember(d => d.UserId, o => o.MapFrom(s => s.UserId))
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id));

        CreateMap<UpdateUserCommand, AppUser>();

        CreateMap<Notification, GetNotificationResponse>();

        CreateMap<PagedResult<Notification>, PagedResult<GetNotificationResponse>>()
            .ForMember(d => d.Items, o => o.MapFrom(s => s.Items));
    }
}
