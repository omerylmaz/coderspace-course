using Library.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.DTOs.Book;

public record GetPagedBooksResponseDto(PagedResult<GetBookResponse> Books);

public record GetBookResponse(
    Guid Id,
    string Title,
    string Author,
    int PublicationYear,
    string ISBN
    );