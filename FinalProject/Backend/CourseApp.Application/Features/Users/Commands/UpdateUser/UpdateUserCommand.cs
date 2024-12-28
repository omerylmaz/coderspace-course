using CourseApp.Application.ResultDto;
using MediatR;
using System.Text.Json.Serialization;

namespace CourseApp.Application.Features.Users.Commands.UpdateUser;

public record UpdateUserCommand : IRequest<Result>
{
    [JsonIgnore]
    public Guid Id { get; init; }

    public string FullName { get; init; }

    public string UserName { get; init; }

    public string Email { get; init; }

    public string PhoneNumber { get; init; }
}
