using FluentValidation;

namespace CourseApp.Application.Features.Users.Commands.SignupUser;

public class SignupUserCommandValidator : AbstractValidator<SignupUserCommand>
{
    public SignupUserCommandValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full Name is required");

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("User Name is required");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid Email format");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters");

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty().WithMessage("Confirm Password is required")
            .Equal(x => x.Password).WithMessage("Passwords do not match");
    }
}
