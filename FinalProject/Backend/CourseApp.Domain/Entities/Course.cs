namespace CourseApp.Domain.Entities;

public class Course : BaseEntity
{
    public string Name { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public Guid? TeacherId { get; set; }
    public Guid CategoryId { get; set; }
    public AppUser? Teacher { get; set; }
    public Category Category { get; set; }
    public ICollection<Order> Orders { get; set; }
    public ICollection<Content> Contents { get; set; }
}
