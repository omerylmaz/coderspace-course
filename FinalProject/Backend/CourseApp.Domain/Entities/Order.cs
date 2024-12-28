using CourseApp.Domain.Enums;

namespace CourseApp.Domain.Entities;

public class Order : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid CourseId { get; set; }
    public AppUser User { get; set; }
    public Course Course { get; set; }
    public Payment Payment { get; set; }
    public OrderStasusses OrderStatus { get; set; }
}
