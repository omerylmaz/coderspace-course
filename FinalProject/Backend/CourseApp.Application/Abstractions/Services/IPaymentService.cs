using CourseApp.Application.DTOs.Payment;

namespace CourseApp.Application.Abstractions.Services;

public interface IPaymentService
{
    Task<GetExternalPaymentResponseDto> Pay(CreatePaymentDto paymentDto, CancellationToken cancellationToken);
}
