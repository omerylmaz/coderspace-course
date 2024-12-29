using CourseApp.Application.ResultDto;
using MediatR;
using System.Text.Json.Serialization;

namespace CourseApp.Application.Features.Users.Commands.ChangePassword;

public record ChangePasswordCommand : IRequest<Result>
{
    [JsonIgnore]
    public Guid UserId { get; init; }
    public string CurrentPassword { get; init; }
    public string NewPassword { get; init; }
}
