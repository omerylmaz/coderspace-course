namespace CourseApp.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Course> Courses { get; set; }
}
