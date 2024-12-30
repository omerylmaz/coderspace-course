using CourseApp.Domain.Enums;

namespace CourseApp.Domain.Entities;

public class Payment : BaseEntity
{
    public Guid OrderId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public Order Order { get; set; }
    public bool ThreeDSStatus{ get; set; }  // 3DS güvenliği
}