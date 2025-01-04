using CourseApp.Application.Abstractions.Repositories;
using CourseApp.Application.Abstractions.Services;
using CourseApp.Application.DTOs.Auth;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace CourseApp.Application.Features.Users.Commands.CreateTokenByRefreshToken;

internal class CreateTokenByRefreshTokenCommandHandler
    (IGenericRepository<UserRefreshToken> refreshTokenRepository, 
    UserManager<AppUser> userManager,
    ITokenService tokenService,
    IUnitOfWork unitOfWork,
    ILogger<CreateTokenByRefreshTokenCommandHandler> logger) : IRequestHandler<CreateTokenByRefreshTokenCommand, Result<CreateTokenByRefreshTokenResponse>>
{
    public async Task<Result<CreateTokenByRefreshTokenResponse>> Handle(CreateTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var existRefreshToken = await refreshTokenRepository.GetWhereAsync(
            x => x.Code == request.RefreshToken || x.OldCode == request.RefreshToken,
            cancellationToken);

        if (existRefreshToken == null)
        {
            logger.LogWarning("Refresh token not found or invalid. Provided token: {Token}", request.RefreshToken);
            return Result<CreateTokenByRefreshTokenResponse>.NotFound("Refresh token not found");
        }

        if (existRefreshToken.OldCode == request.RefreshToken
            && existRefreshToken.Expiration < DateTime.UtcNow.AddSeconds(-10))
        {
            logger.LogWarning("Old refresh token expired. Token Id: {Id}", existRefreshToken.Id);
            return Result<CreateTokenByRefreshTokenResponse>.NotFound("Refresh token expired, please login again");
        }

        if (existRefreshToken.Expiration < DateTime.UtcNow)
        {
            logger.LogWarning("Refresh token expired. Token Id: {Id}", existRefreshToken.Id);
            return Result<CreateTokenByRefreshTokenResponse>.NotFound("Refresh token expired, please login again");
        }

        var user = await userManager.FindByIdAsync(existRefreshToken.UserId.ToString());

        if (user == null)
        {
            logger.LogWarning("User not found. User Id: {UserId}", existRefreshToken.UserId);
            return Result<CreateTokenByRefreshTokenResponse>.NotFound("User not found");
        }

        TokenDto tokenDto = tokenService.CreateToken(user);

        existRefreshToken.OldCode = existRefreshToken.Code;

        existRefreshToken.Code = tokenDto.RefreshToken;
        existRefreshToken.Expiration = tokenDto.RefreshTokenExpiration;

        await unitOfWork.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Refresh token successfully updated for User Id: {UserId}", user.Id);

        return Result<CreateTokenByRefreshTokenResponse>.Success(new CreateTokenByRefreshTokenResponse(tokenDto));
    }

}