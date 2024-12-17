using AutoMapper;
using Library.Application.DTOs.Book;
using Library.Application.DTOs.User;
using Library.Application.Result;
using Library.Domain.Entities;
using Library.Domain.Pagination;
using Library.Web.ViewModels.Book;
using Library.Web.ViewModels.User;

namespace Library.Web;

internal class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<GetPagedBooksResponseDto, PagedResult<GetBookListVM>>()
            .ForMember(d => d.Items, o => o.MapFrom(s => s.Books.Items))
            .ForMember(d => d.PageNumber, o => o.MapFrom(s => s.Books.PageNumber))
            .ForMember(d => d.PageSize, o => o.MapFrom(s => s.Books.PageSize))
            .ForMember(d => d.TotalCount, o => o.MapFrom(s => s.Books.TotalCount));

        CreateMap<GetBookResponse, GetBookListVM>();

        CreateMap<GetBookByIdResponseDto, GetBookDetailVM>();

        CreateMap<GetUserListResponseDto, GetUserListVM>();

        CreateMap<GetUserDetailResponseDto, EditUserVM>()
             //.ForMember(d => d.OldPassword, o => o.Ignore())
             //.ForMember(d => d.NewPassword, o => o.Ignore())
             //.ForMember(d => d.ConfirmNewPassword, o => o.Ignore())
             ;

        //CreateMap<EditUserVM, AppUser>();
    }
}
