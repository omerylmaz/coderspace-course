using Library.Application.DTOs.User;
using Library.Application.Result;
using Library.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Abstractions.Services;

public interface IUserService
{
    Task<Result.Result> CreateUserAsync(SignupUserRequestDto user, CancellationToken cancellationToken);

    Task<Result<List<GetUserListResponseDto>>> GetAllUsersAsync(CancellationToken cancellationToken);

    Task<Result<GetUserDetailResponseDto>> GetUserByIdAsync(string id, CancellationToken cancellationToken);

    Task<Result.Result> UpdateUserAsync(EditUserDto updatedUser, CancellationToken cancellationToken);

    Task<Result.Result> DeleteUserAsync(string id, CancellationToken cancellationToken);

    Task<Result.Result> SignInUserAsync(SignInDto model, CancellationToken cancellationToken);

    Task Logout();
}
