using CourseApp.Application.DTOs.Auth;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using Final.Application.Abstractions.Repositories;
using Final.Application.Abstractions.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CourseApp.Application.Features.Users.Commands.CreateTokenByRefreshToken;

internal class CreateTokenByRefreshTokenCommandHandler
    (IGenericRepository<UserRefreshToken> refreshTokenRepository, 
    UserManager<AppUser> userManager,
    ITokenService tokenService,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateTokenByRefreshTokenCommand, Result<CreateTokenByRefreshTokenResponse>>
{
    public async Task<Result<CreateTokenByRefreshTokenResponse>> Handle(CreateTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var existRefreshToken = await refreshTokenRepository.GetWhereAsync(x => x.Code == request.RefreshToken, cancellationToken);

        if (existRefreshToken == null)
            return Result<CreateTokenByRefreshTokenResponse>.NotFound("Refresh token not found");

        if (existRefreshToken.Expiration < DateTime.Now)
            return Result<CreateTokenByRefreshTokenResponse>.NotFound("Refresh token expired, please login again");

        var user = await userManager.FindByIdAsync(existRefreshToken.UserId.ToString());

        if (user == null)
            return Result<CreateTokenByRefreshTokenResponse>.NotFound("User Id not found");

        TokenDto tokenDto = tokenService.CreateToken(user);

        existRefreshToken.Code = tokenDto.RefreshToken;
        existRefreshToken.Expiration = tokenDto.RefreshTokenExpiration;

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<CreateTokenByRefreshTokenResponse>.Success(new CreateTokenByRefreshTokenResponse(tokenDto));
    }
}