using CourseApp.Application.DTOs.Auth;
using CourseApp.Application.ResultDto;
using MediatR;

namespace CourseApp.Application.Features.Users.Commands.LoginUser;

public class LoginUserCommand : IRequest<Result<LoginUserResponse>>
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public record LoginUserResponse
{
    public TokenDto Token { get; init; }
}