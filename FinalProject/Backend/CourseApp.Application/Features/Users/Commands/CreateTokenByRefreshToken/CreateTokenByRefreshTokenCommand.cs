using CourseApp.Application.DTOs.Auth;
using CourseApp.Application.ResultDto;
using MediatR;

namespace CourseApp.Application.Features.Users.Commands.CreateTokenByRefreshToken;

public record CreateTokenByRefreshTokenCommand(string RefreshToken) : IRequest<Result<CreateTokenByRefreshTokenResponse>>;

public record CreateTokenByRefreshTokenResponse(TokenDto Token);