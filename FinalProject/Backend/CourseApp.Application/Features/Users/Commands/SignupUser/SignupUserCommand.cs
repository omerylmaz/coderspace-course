using CourseApp.Application.ResultDto;
using MediatR;

namespace CourseApp.Application.Features.Users.Commands.SignupUser;

public record SignupUserCommand : IRequest<Result<SignupUserResponse>>
{
    public string FullName { get; init; }
    public string UserName { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
    public string ConfirmPassword { get; init; }
    public string PhoneNumber { get; init; }
    //public UserRoles Role { get; init; }
};

public record SignupUserResponse
(
    Guid Id
);