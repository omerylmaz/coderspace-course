using CourseApp.Application.Abstractions.Repositories;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Enums;
using Final.Application.Abstractions.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CourseApp.Application.Features.Orders.Commands.CompleteOrder;

internal class CompleteOrderCommandHandler(
    IOrderRepository orderRepository,
    IPaymentRepository paymentRepository,
    IUnitOfWork unitOfWork,
    ILogger<CompleteOrderCommandHandler> logger) : IRequestHandler<CompleteOrderCommand, Result>
{
    public async Task<Result> Handle(CompleteOrderCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling CompleteOrderCommand for Conversation ID: {ConversationId}", request.ConversationId);

        if (request.Status != "success")
        {
            logger.LogWarning("Payment failed. Conversation ID {ConversationId}", request.ConversationId);
            return Result.BadRequest("Payment Failed, security code you entered may be wrong");
        }

        var payment = await paymentRepository.GetByIdAsync(Guid.Parse(request.ConversationId), cancellationToken);
        if (payment == null)
        {
            logger.LogWarning("Payment not found. Conversation ID {ConversationId}", request.ConversationId);
            return Result.NotFound($"Payment with id {request.ConversationId} not found");
        }

        payment.ThreeDSStatus = true;
        paymentRepository.Update(payment);

        var order = await orderRepository.GetOrderDetailWhereAsync(x => x.Payment.Id == Guid.Parse(request.ConversationId), cancellationToken);
        if (order == null)
        {
            logger.LogWarning("Order not found for Payment ID {PaymentId}", request.ConversationId);
            return Result.NotFound($"Order associated with Payment ID {request.ConversationId} not found");
        }

        order.OrderStatus = OrderStasusses.Completed;
        orderRepository.Update(order);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
