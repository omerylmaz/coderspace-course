using MediatR;
using Microsoft.AspNetCore.Identity;
using CourseApp.Application.Abstractions.Services;
using CourseApp.Application.Features.Users.Commands.LoginUser;
using CourseApp.Application.Abstractions.Repositories;
using CourseApp.Domain.Entities;
using CourseApp.Application.ResultDto;
using Microsoft.Extensions.Logging;

namespace CourseApp.Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommandHandler(
        UserManager<AppUser> userManager,
        ITokenService tokenService,
        IGenericRepository<UserRefreshToken> refreshTokenRepository,
        IUnitOfWork unitOfWork,
        ILogger<LoginUserCommandHandler> logger
            ) : IRequestHandler<LoginUserCommand, Result<LoginUserResponse>>
    {
        public async Task<Result<LoginUserResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);

            if (user == null || !await userManager.CheckPasswordAsync(user, request.Password))  //TODO burayı düzelt
            {
                logger.LogWarning("User entered email or password wrong");
                return Result<LoginUserResponse>.Conflict("Email or password wrong");
            }

            var token = tokenService.CreateToken(user);

            var userRefreshToken = await refreshTokenRepository.GetWhereAsync(x => x.UserId == user.Id, cancellationToken);

            if (userRefreshToken == null)
            {
                await refreshTokenRepository.AddAsync(new UserRefreshToken { UserId = user.Id, Code = token.RefreshToken, Expiration = token.RefreshTokenExpiration }, cancellationToken);
            }
            else
            {
                userRefreshToken.Code = token.RefreshToken;
                userRefreshToken.Expiration = token.RefreshTokenExpiration;
            }

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<LoginUserResponse>.Success(new LoginUserResponse { Token = token });
        }
    }
}
