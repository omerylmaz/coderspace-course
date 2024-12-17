namespace Library.Web.ViewModels.Book;

public record GetBookListVM
(
    Guid Id,
    string Title,
    
    string Author,
    
    int PublicationYear,
    
    string ISBN
);
