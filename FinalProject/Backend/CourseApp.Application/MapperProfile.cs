using AutoMapper;
using CourseApp.Application.DTOs.Course;
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
        //CreateMap<PagedResult<Book>, PagedResult<GetBookResponse>>();

        //CreateMap<Book, GetBookResponse>();

        //CreateMap<CreateBookRequestDto, Book>();

        //CreateMap<Book, GetBookByIdResponseDto>();

        CreateMap<SignupUserCommand, AppUser>();

        //CreateMap<AppUser, GetUserListResponseDto>();

        //CreateMap<AppUser, GetUserDetailResponseDto>();

        //CreateMap<EditUserDto, AppUser>();

        //CreateMap<AppRole, GetRoleListDto>();

        //CreateMap<AppRole, GetRoleDetailDto>();

        CreateMap<CreateCourseCommand, Course>();

        CreateMap<UpdateCourseCommand, Course>();

        CreateMap<Course, GetCourseByIdResponse>();

        CreateMap<Course, GetCourseResponseDto>()
            .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category.Name));

        CreateMap<PagedResult<Course>, PagedResult<GetCourseResponseDto>>()
            .ForMember(d => d.Items, o => o.MapFrom(s => s.Items));

        //CreateMap<Course, GetCourseResponseDto>();

        //CreateMap<PagedResult<Course>, PagedResult<GetCourseResponseDto>>()
        //    .ForMember(d => d.Items, o => o.MapFrom(s => s.Items));

        //CreateMap<Course, GetCourseResponseDto>();

        //CreateMap<PagedResult<Course>, PagedResult<GetCourseResponseDto>>()
        //    .ForMember(d => d.Items, o => o.MapFrom(s => s.Items));

        CreateMap<Order, GetOrderResponse>();

        //CreateMap<PagedResult<Order>, PagedResult<GetOrderResponse>>()
        //    .ForMember(d => d.Items, o => o.MapFrom(s => s.Items));
    }
}
