namespace CourseApp.Domain.Entities;

public class Notification : BaseEntity
{
    public Guid UserId { get; set; }

    public string Title { get; set; }

    public string Message { get; set; }

    public bool IsRead { get; set; } = false;

    public AppUser User { get; set; }
}
