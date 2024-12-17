using AutoMapper;
using Library.Application.DTOs.Book;
using Library.Application.DTOs.Role;
using Library.Application.DTOs.User;
using Library.Domain.Entities;
using Library.Domain.Pagination;

namespace Library.Application;

internal class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<PagedResult<Book>, PagedResult<GetBookResponse>>();

        CreateMap<Book, GetBookResponse>();

        CreateMap<CreateBookRequestDto, Book>();

        CreateMap<Book, GetBookByIdResponseDto>();

        CreateMap<SignupUserRequestDto, AppUser>();

        CreateMap<AppUser, GetUserListResponseDto>();

        CreateMap<AppUser, GetUserDetailResponseDto>();

        CreateMap<EditUserDto, AppUser>();

        CreateMap<AppRole, GetRoleListDto>();

        CreateMap<AppRole, GetRoleDetailDto>();
    }
}
