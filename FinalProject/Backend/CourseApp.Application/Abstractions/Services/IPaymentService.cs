namespace CourseApp.Application.Abstractions.Services;

public interface IPaymentService
{
    Task<string> Pay(CreatePaymentDto paymentDto, CancellationToken cancellationToken);
}
