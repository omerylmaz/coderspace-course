using AutoMapper;
using Library.Application.Features.Books.Commands.CreateBook;
using Library.Application.Features.Books.Commands.UpdateBook;
using Library.Application.Features.Books.Queries.GetBookById;
using Library.Application.Features.Books.Queries.GetPagedBooks;
using Library.Domain.Entities;
using Library.Domain.Enums;
using Library.Domain.Pagination;

namespace Library.Application;

internal class MapperProfile : Profile
{
	public MapperProfile()
	{
		CreateMap<CreateBookCommand, Book>();

		CreateMap<Book, GetBookByIdResponse>()
			.ForMember(d => d.Status, o => o.MapFrom(s => s.Status.ToString()));

		CreateMap<Book, GetBookResponse>();

		CreateMap<PagedResult<Book>, PagedResult<GetBookResponse>>()
			.ForMember(d => d.Items, o => o.MapFrom(s => s.Items));

		CreateMap<Book, GetBookResponse>()
			.ForMember(d => d.Status, o => o.MapFrom(s => s.Status.ToString()));

		CreateMap<UpdateBookCommand, Book>();
    }
}
