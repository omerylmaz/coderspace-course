using Library.Application.DTOs.Role;
using Library.Application.Result;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Abstractions.Services;

public interface IRoleService
{
    Task<Result.Result> CreateRoleAsync(CreateRoleDto roleDto, CancellationToken cancellationToken);

    Task<Result<List<GetRoleListDto>>> GetAllRolesAsync(CancellationToken cancellationToken);

    Task<Result.Result> UpdateRoleAsync(UpdateRoleDto roleDto, CancellationToken cancellationToken);

    Task<Result.Result> DeleteRoleAsync(string id, CancellationToken cancellationToken);

    Task<Result.Result> AssignRoleToUserAsync(Guid userId, List<AssignRoleToUserDto> assignRoleDto, CancellationToken cancellationToken);

    Task<Result.Result> RemoveRoleFromUserAsync(AssignRoleDto assignRoleDto, CancellationToken cancellationToken);

    Task<Result<GetRoleDetailDto>> GetRoleByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<Result<List<AssignRoleToUserDto>>> GetUserRolesAsync(Guid userId, CancellationToken cancellationToken);

    Task<Result.Result> UpdateUserRolesAsync(string userId, List<AssignRoleToUserDto> roles, CancellationToken cancellationToken);
}
