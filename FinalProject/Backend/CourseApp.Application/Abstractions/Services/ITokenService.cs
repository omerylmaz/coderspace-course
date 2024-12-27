using CourseApp.Application.DTOs.Auth;
using CourseApp.Domain.Entities;

namespace Final.Application.Abstractions.Services;

public interface ITokenService
{
    TokenDto CreateToken(AppUser user);
}