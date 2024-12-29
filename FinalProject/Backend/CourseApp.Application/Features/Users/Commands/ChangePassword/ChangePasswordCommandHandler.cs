using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CourseApp.Application.Features.Users.Commands.ChangePassword;

internal class ChangePasswordCommandHandler(UserManager<AppUser> userManager) : IRequestHandler<ChangePasswordCommand, Result>
{
    public async Task<Result> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.UserId.ToString());
        if (user == null)
        {
            return Result.NotFound($"User with id {request.UserId} not found");
        }

        var changePasswordResult = await userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);

        if (!changePasswordResult.Succeeded)
        {
            var errors = changePasswordResult.Errors.Select(e => e.Description).ToList();

            return Result.BadRequest("some errors during change password", errors: errors);
        }

        return Result.Success();

    }
}
