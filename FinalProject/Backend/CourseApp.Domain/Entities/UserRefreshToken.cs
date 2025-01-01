namespace CourseApp.Domain.Entities;

public class UserRefreshToken : BaseEntity
{
    public Guid UserId { get; set; }
    public string Code { get; set; }
    public string? OldCode { get; set; }
    public DateTime Expiration { get; set; }
}