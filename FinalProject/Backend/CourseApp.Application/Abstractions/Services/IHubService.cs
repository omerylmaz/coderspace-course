using CourseApp.Application.DTOs.Payment;

namespace CourseApp.Application.Abstractions.Services;

public interface IPaymentHubService
{
    Task NotifyUserForPayment(NotifyUserForPaymentRequestDto notifyUserForPaymentRequest, CancellationToken cancellationToken);
}
