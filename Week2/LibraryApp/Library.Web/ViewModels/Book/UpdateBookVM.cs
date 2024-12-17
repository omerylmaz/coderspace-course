namespace Library.Web.ViewModels.Book;

public record UpdateBookVM
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
