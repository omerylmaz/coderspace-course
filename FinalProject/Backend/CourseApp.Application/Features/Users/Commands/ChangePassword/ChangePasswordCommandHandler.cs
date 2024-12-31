using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace CourseApp.Application.Features.Users.Commands.ChangePassword;

internal class ChangePasswordCommandHandler(UserManager<AppUser> userManager, ILogger<ChangePasswordCommandHandler> logger) : IRequestHandler<ChangePasswordCommand, Result>
{
    public async Task<Result> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.UserId.ToString());
        if (user == null)
        {
            logger.LogWarning("User with Id {Id} not found", request.UserId);
            return Result.NotFound($"User with id {request.UserId} not found");
        }

        var changePasswordResult = await userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);

        if (!changePasswordResult.Succeeded)
        {
            var errors = changePasswordResult.Errors.Select(e => e.Description).ToList();
            logger.LogWarning("Password could not changed with errors: {Errors}", string.Join(", ", errors));

            return Result.BadRequest("some errors during change password", errors: errors);
        }

        return Result.Success();

    }
}
