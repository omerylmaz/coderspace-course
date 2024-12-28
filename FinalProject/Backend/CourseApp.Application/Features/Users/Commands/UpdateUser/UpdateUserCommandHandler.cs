using AutoMapper;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using Final.Application.Abstractions.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CourseApp.Application.Features.Users.Commands.UpdateUser;

internal class UpdateUserCommandHandler(UserManager<AppUser> userManager, IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<UpdateUserCommand, Result>
{
    public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Id.ToString());

        if (user == null)
            return Result.NotFound($"{request.Id} id not found");

        if (!string.IsNullOrWhiteSpace(request.FullName))
        {
            user.FullName = request.FullName;
        }

        if (!string.IsNullOrWhiteSpace(request.UserName) && user.UserName != request.UserName)
        {
            var userWithSameUser = await userManager.FindByNameAsync(request.UserName);
            if (userWithSameUser != null)
            {
                return Result.Conflict($"UserName '{request.UserName}' is already taken");
            }

            user.UserName = request.UserName;
        }

        if (!string.IsNullOrWhiteSpace(request.Email) && user.Email != request.Email)
        {
            var userWithSameEmail = await userManager.FindByEmailAsync(request.Email);
            if (userWithSameEmail != null)
            {
                return Result.Conflict($"Email '{request.Email}' is already taken");
            }

            user.Email = request.Email;
        }

        if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
        {
            user.PhoneNumber = request.PhoneNumber;
        }

        var result = await userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            return Result.BadRequest("Some errors happened", errors: result.Errors.Select(e => e.Description).ToList());
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
