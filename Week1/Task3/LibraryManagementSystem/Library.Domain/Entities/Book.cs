using Library.Domain.Enums;
using System.Diagnostics;

namespace Library.Domain.Entities;

public class Book : BaseEntity
{
    public string Name { get; set; }
    public string Category { get; set; }
    public string Author { get; set; }
    public int Pages { get; set; }
    public BookStatus Status { get; set; }
    public DateOnly PublishedDate { get; set; }
    public decimal Price { get; set; }
}
