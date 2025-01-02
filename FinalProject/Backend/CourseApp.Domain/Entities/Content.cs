namespace CourseApp.Domain.Entities;

public class Content : BaseEntity
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public TimeSpan Duration { get; set; }
    public Guid CourseId { get; set; }
    public Course Course { get; set; }
}