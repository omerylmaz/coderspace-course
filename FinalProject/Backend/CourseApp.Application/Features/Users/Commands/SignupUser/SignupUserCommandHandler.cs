using AutoMapper;
using CourseApp.Application.Abstractions.Events;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using CourseApp.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Threading;

namespace CourseApp.Application.Features.Users.Commands.SignupUser;

internal class SignupUserCommandHandler(
    IMapper mapper, 
    UserManager<AppUser> userManager, 
    RoleManager<AppRole> roleManager, 
    ILogger<SignupUserCommandHandler> logger,
    IEventPublisher eventPublisher) 
    : IRequestHandler<SignupUserCommand, Result<SignupUserResponse>>
{
    public async Task<Result<SignupUserResponse>> Handle(SignupUserCommand request, CancellationToken cancellationToken)
    {
        if (!request.Password.Equals(request.ConfirmPassword))
        {
            return Result<SignupUserResponse>.Conflict("Password does not match with confirm password");
        }
        var user = mapper.Map<AppUser>(request);
        user.Id = Guid.NewGuid();

        var result = await userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(x => x.Description).ToList();
            logger.LogWarning("Registration failed with errors: {Errors}", string.Join(", ", errors));
            return Result<SignupUserResponse>.BadRequest(title: "Some errors happened", errors: errors);
        }


        var roleResult = await userManager.AddToRoleAsync(user, UserRoles.User.ToString());

        if (!roleResult.Succeeded)
        {
            var errors = roleResult.Errors.Select(x => x.Description).ToList();
            return Result<SignupUserResponse>.BadRequest(title: "Some errors happened", errors: errors);
        }

        await PublishEmailRegisteredToUserAsync(request.FullName, request.Email, cancellationToken);

        return Result<SignupUserResponse>.Success(new SignupUserResponse(user.Id));
    }

    private async Task PublishEmailRegisteredToUserAsync(string fullName, string email, CancellationToken cancellationToken)
    {
        var subject = "Registration Successful!";
        var body = $"Welcome to our app {fullName}. Your registration is successful.";

        await eventPublisher.PublishEmailRegisteredAsync(email, subject, body, cancellationToken);
    }
}
