using FluentValidation;

namespace CourseApp.Application.Features.Payments.Commands.CreatePayment;

public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
{
    public CreatePaymentCommandValidator()
    {
        RuleFor(x => x.UserID)
            .NotEmpty();

        RuleFor(x => x.CardHolderName)
            .NotEmpty().WithMessage("Card holder name is required.");

        RuleFor(x => x.CardNumber)
            .NotEmpty().WithMessage("Card number is required.")
            .CreditCard().WithMessage("Card number must be valid.");

        RuleFor(x => x.ExpireMonth)
            .NotEmpty().WithMessage("Expire month is required.")
            .Matches(@"^(0[1-9]|1[0-2])$").WithMessage("Expire month must be between 01 and 12.");

        RuleFor(x => x.ExpireYear)
                   .NotEmpty().WithMessage("Expire year is required.")
                   .Matches(@"^\d{4}$").WithMessage("Expire year must be a valid 4-digit year.")
                   .Must(y => int.Parse(y) >= DateTime.Now.Year).WithMessage("Expire year must be in the future.");

        RuleFor(x => x.Cvc)
            .NotEmpty().WithMessage("CVC is required.")
            .Matches(@"^\d{3,4}$").WithMessage("CVC must be 3 digits.");

        RuleFor(x => x.CourseId)
            .NotEmpty();
    }
}
