using FluentValidation;

namespace CourseApp.Application.Features.Orders.Commands.UpdateOrder;

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.CourseId).NotEmpty();

        RuleFor(x => x.OrderStatus)
            .IsInEnum().WithMessage("Order Status must be a valid value.");
    }
}
