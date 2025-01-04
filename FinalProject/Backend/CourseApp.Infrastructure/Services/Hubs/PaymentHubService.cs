using CourseApp.Application.Abstractions.Services;
using CourseApp.Application.DTOs.Payment;
using CourseApp.Infrastructure.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace CourseApp.Infrastructure.Services.Hubs;

internal class PaymentHubService(IHubContext<PayHub> payHub) : IPaymentHubService
{
    public async Task NotifyUserForPayment(NotifyUserForPaymentRequestDto notifyUserForPaymentRequest, CancellationToken cancellationToken)
    {
        await payHub.Clients.Client(PayHub.TransactionConnections[notifyUserForPaymentRequest.ConversationId])
            .SendAsync("ReceivePayment", notifyUserForPaymentRequest, cancellationToken);
    }
}
