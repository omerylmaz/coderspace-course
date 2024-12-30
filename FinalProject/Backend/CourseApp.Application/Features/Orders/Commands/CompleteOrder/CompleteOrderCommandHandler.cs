using CourseApp.Application.Abstractions.Repositories;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Enums;
using Final.Application.Abstractions.Repositories;
using MediatR;

namespace CourseApp.Application.Features.Orders.Commands.CompleteOrder;

internal class CompleteOrderCommandHandler(
    IOrderRepository orderRepository,
    IPaymentRepository paymentRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CompleteOrderCommand, Result>
{
    public async Task<Result> Handle(CompleteOrderCommand request, CancellationToken cancellationToken)
    {
        if (request.Status != "success")
        {
            return Result.BadRequest("Payment Failed, security code you enterd may be wrong");
        }

        var payment = await paymentRepository.GetByIdAsync(Guid.Parse(request.ConversationId), cancellationToken);
        if (payment == null)
        {
            return Result.NotFound($"Payment with id {request.ConversationId} not found");
        }

        payment.ThreeDSStatus = true;
        paymentRepository.Update(payment);

        try
        {
            var order = await orderRepository.GetOrderDetailWhereAsync(x => x.Payment.Id == Guid.Parse(request.ConversationId), cancellationToken);
            order.OrderStatus = OrderStasusses.Completed;
            orderRepository.Update(order);
        }
        catch (Exception e)
        {

            throw;
        }


        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
