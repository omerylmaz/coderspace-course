using AutoMapper;
using global::Library.Domain.Entities;
using Library.Application.Abstractions.Repositories;
using Library.Application.Abstractions.Services;
using Library.Application.DTOs.Role;
using Library.Application.Result;
using Microsoft.AspNetCore.Identity;

namespace Library.Application.Services;

internal class RoleService(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, IUnitOfWork unitOfWork, IMapper mapper) : IRoleService
{
    public async Task<Result.Result> CreateRoleAsync(CreateRoleDto roleDto, CancellationToken cancellationToken)
    {
        var roleExists = await roleManager.RoleExistsAsync(roleDto.Name);
        if (roleExists)
        {
            return Result.Result.Conflict($"Role '{roleDto.Name}' already exists");
        }

        var result = await roleManager.CreateAsync(new AppRole() { Id = Guid.NewGuid(), Name = roleDto.Name });
        if (!result.Succeeded)
        {
            var errorDetails = string.Join("; ", result.Errors.Select(e => e.Description));
            return Result.Result.BadRequest("Some error happened during role creation", errorDetails);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Result.Success();
    }

    public async Task<Result<List<GetRoleListDto>>> GetAllRolesAsync(CancellationToken cancellationToken)
    {
        var roles = roleManager.Roles.ToList();
        var rolesResponse = mapper.Map<List<GetRoleListDto>>(roles);

        if (!roles.Any())
        {
            return Result<List<GetRoleListDto>>.NotFound("No roles found");
        }

        return Result<List<GetRoleListDto>>.Success(rolesResponse);
    }

    public async Task<Result<GetRoleDetailDto>> GetRoleByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var role = roleManager.Roles.FirstOrDefault(x => x.Id == id);

        if (role == null)
        {
            return Result<GetRoleDetailDto>.NotFound("Role not found");
        }

        var roleResponse = mapper.Map<GetRoleDetailDto>(role);

        return Result<GetRoleDetailDto>.Success(roleResponse);
    }

    public async Task<Result.Result> UpdateRoleAsync(UpdateRoleDto roleDto, CancellationToken cancellationToken)
    {
        var role = await roleManager.FindByIdAsync(roleDto.Id);
        if (role == null)
        {
            return Result.Result.NotFound($"Role with {roleDto.Id} id  not found");
        }

        role.Name = roleDto.Name;

        var result = await roleManager.UpdateAsync(role);
        if (!result.Succeeded)
        {
            var errorDetails = string.Join("; ", result.Errors.Select(e => e.Description));
            return Result.Result.BadRequest("Some error happened during role update", errorDetails);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Result.Success();
    }

    public async Task<Result.Result> DeleteRoleAsync(string id, CancellationToken cancellationToken)
    {
        var role = await roleManager.FindByIdAsync(id);
        if (role == null)
        {
            return Result.Result.NotFound($"Role with {id} id not found");
        }

        var result = await roleManager.DeleteAsync(role);
        if (!result.Succeeded)
        {
            var errorDetails = string.Join("; ", result.Errors.Select(e => e.Description));
            return Result.Result.BadRequest("Some error happened during role deletion", errorDetails);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Result.Success();
    }

    public async Task<Result.Result> AssignRoleToUserAsync(Guid userId, List<AssignRoleToUserDto> assignRoleDto, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(userId.ToString());
        if (user == null)
        {
            return Result.Result.NotFound($"User with {assignRoleDto} id not found");
        }
        foreach (var role in assignRoleDto)
        {

            if (role.Exist)
            {
                await userManager.AddToRoleAsync(user, role.Name);

            }
            else
            {
                await userManager.RemoveFromRoleAsync(user, role.Name);
            }

        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Result.Success();
    }

    public async Task<Result.Result> RemoveRoleFromUserAsync(AssignRoleDto assignRoleDto, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(assignRoleDto.UserId);
        if (user == null)
        {
            return Result.Result.NotFound($"User with {assignRoleDto.UserId} id not found");
        }

        var result = await userManager.RemoveFromRoleAsync(user, assignRoleDto.RoleName);
        if (!result.Succeeded)
        {
            var errorDetails = string.Join("; ", result.Errors.Select(e => e.Description));
            return Result.Result.BadRequest("Some error happened during role remove", errorDetails);
        }


        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Result.Success();
    }

    public async Task<Result<List<AssignRoleToUserDto>>> GetUserRolesAsync(Guid userId, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(userId.ToString());
        if (user == null)
        {
            return Result<List<AssignRoleToUserDto>>.NotFound($"User with {userId} id not found.");
        }

        var roles = roleManager.Roles.ToList();
        var userRoles = await userManager.GetRolesAsync(user);

        var roleViewModelList = roles.Select(role => new AssignRoleToUserDto
        (
            role.Id,
            role.Name,
            userRoles.Contains(role.Name)
        )).ToList();


        return Result<List<AssignRoleToUserDto>>.Success(roleViewModelList);
    }

    public async Task<Result.Result> UpdateUserRolesAsync(string userId, List<AssignRoleToUserDto> roles, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return Result.Result.NotFound($"User with {userId} id not found.");
        }

        foreach (var role in roles)
        {
            if (role.Exist)
            {
                if (!await userManager.IsInRoleAsync(user, role.Name))
                {
                    await userManager.AddToRoleAsync(user, role.Name);
                }
            }
            else
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    await userManager.RemoveFromRoleAsync(user, role.Name);
                }
            }
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Result.Success();
    }
}