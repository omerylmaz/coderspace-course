namespace Library.Domain.Entities;

public class Book : BaseEntity
{
    public string Title { get; set; }

    public string Author { get; set; }

    public int PublicationYear { get; set; }

    public string ISBN { get; set; }

    public string Genre { get; set; }

    public string Publisher { get; set; }

    public int PageCount { get; set; }

    public string Language { get; set; }

    public string Summary { get; set; }
    public int AvailableCopies { get; set; }

    public Book() { }

    public Book(Guid id, string title, string author, int publicationYear, string isbn, string genre, string publisher, int pageCount, string language, string summary, int availableCopies)
    {
        Id = id;
        Title = title;
        Author = author;
        PublicationYear = publicationYear;
        ISBN = isbn;
        Genre = genre;
        Publisher = publisher;
        PageCount = pageCount;
        Language = language;
        Summary = summary;
        AvailableCopies = availableCopies;
    }
}
