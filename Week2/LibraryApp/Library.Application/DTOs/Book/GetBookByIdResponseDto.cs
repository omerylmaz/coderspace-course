namespace Library.Application.DTOs.Book;

public record GetBookByIdResponseDto
(
    Guid Id,
    string Title,
    string Author,
    int PublicationYear,
    string ISBN,
    string Genre,
    string Publisher,
    int PageCount,
    string Language,
    string Summary,
    int AvailableCopies
);