using MediatR;
using Microsoft.AspNetCore.Identity;
using Final.Application.Abstractions.Services;
using Final.Application.Features.Users.Commands.LoginUser;
using Final.Application.Abstractions.Repositories;
using CourseApp.Domain.Entities;
using CourseApp.Application.ResultDto;

namespace Final.Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<LoginUserResponse>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IGenericRepository<UserRefreshToken> _refreshTokenRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LoginUserCommandHandler(
            UserManager<AppUser> userManager, 
            ITokenService tokenService, 
            IGenericRepository<UserRefreshToken> refreshTokenRepository,
            IUnitOfWork unitOfWork
            )
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _refreshTokenRepository = refreshTokenRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<LoginUserResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return Result<LoginUserResponse>.Conflict("Invalid email or password.");
            }

            var token = _tokenService.CreateToken(user);

            var userRefreshToken = await _refreshTokenRepository.GetWhereAsync(x => x.UserId == user.Id, cancellationToken);

            if (userRefreshToken == null)
            {
                await _refreshTokenRepository.AddAsync(new UserRefreshToken { UserId = user.Id, Code = token.RefreshToken, Expiration = token.RefreshTokenExpiration }, cancellationToken);
            }
            else
            {
                userRefreshToken.Code = token.RefreshToken;
                userRefreshToken.Expiration = token.RefreshTokenExpiration;
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<LoginUserResponse>.Success(new LoginUserResponse { Token = token });
        }
    }
}
