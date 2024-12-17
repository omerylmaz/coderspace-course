using AutoMapper;
using Library.Application.Abstractions.Repositories;
using Library.Application.Abstractions.Services;
using Library.Application.DTOs.User;
using Library.Application.Result;
using Library.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Application.Services;

internal class UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IUnitOfWork unitOfWork, IMapper mapper) : IUserService
{

    public async Task<Result.Result> CreateUserAsync(SignupUserRequestDto user, CancellationToken cancellationToken)
    {
        AppUser appUser = mapper.Map<AppUser>(user);
        appUser.Id = Guid.NewGuid();

        var userDb = await userManager.FindByNameAsync(user.UserName);
        if (userDb != null)
        {
            return Result.Result.Conflict("User already exists with this username");
        }

        var result = await userManager.CreateAsync(appUser, user.Password);
        if (!result.Succeeded)
        {
            var errorDetails = string.Join("; ", result.Errors.Select(e => e.Description));
            return Result.Result.BadRequest("Some error happened during create", errorDetails);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Result.Success();
    }

    public async Task<Result.Result> SignInUserAsync(SignInDto model, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            return Result.Result.BadRequest("Email or password is incorrect");
        }

        var signInResult = await signInManager.PasswordSignInAsync(user, model.Password, false, lockoutOnFailure: true);

        if (!signInResult.Succeeded)
        {
            var failedCount = await userManager.GetAccessFailedCountAsync(user);
            return Result.Result.BadRequest($"Email or password is incorrect");
        }

        return Result.Result.Success();
    }


    public async Task<Result<List<GetUserListResponseDto>>> GetAllUsersAsync(CancellationToken cancellationToken)
    {
        var users = userManager.Users.ToList();

        var usersResponse = mapper.Map<List<GetUserListResponseDto>>(users);

        if (!users.Any())
        {
            return Result<List<GetUserListResponseDto>>.NotFound("No users found");
        }


        return Result<List<GetUserListResponseDto>>.Success(usersResponse);
    }

    public async Task<Result<GetUserDetailResponseDto>> GetUserByIdAsync(string id, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(id);

        var userResponse = mapper.Map<GetUserDetailResponseDto>(user);
        if (user == null)
        {
            return Result<GetUserDetailResponseDto>.NotFound($"User with {id} id not found");
        }

        return Result<GetUserDetailResponseDto>.Success(userResponse);
    }

    public async Task<Result.Result> UpdateUserAsync(EditUserDto user, CancellationToken cancellationToken)
    {
        var userDbExists = await userManager.FindByNameAsync(user.UserName);
        //if (userDbExists != null)
        //{
        //    return Result.Result.Conflict("User already exists with this username");
        //}

        var userDb = await userManager.FindByIdAsync(user.Id.ToString());
        if (userDb == null)
        {
            return Result.Result.NotFound($"User with {user.Id} id not found");
        }

        mapper.Map(user, userDb);

        var result = await userManager.UpdateAsync(userDb);
        if (!result.Succeeded)
        {
            var errorDetails = string.Join("; ", result.Errors.Select(e => e.Description));
            return Result.Result.BadRequest("Some error happened during update", errorDetails);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Result.Success();
    }

    public async Task<Result.Result> DeleteUserAsync(string id, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(id);
        if (user == null)
        {
            return Result.Result.NotFound($"User with {id} id not found.");
        }

        var result = await userManager.DeleteAsync(user);
        if (!result.Succeeded)
        {
            var errorDetails = string.Join("; ", result.Errors.Select(e => e.Description));
            return Result.Result.BadRequest("Some error happened during delete", errorDetails);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Result.Success();
    }

    public async Task Logout()
    {
        await signInManager.SignOutAsync();
    }


}
