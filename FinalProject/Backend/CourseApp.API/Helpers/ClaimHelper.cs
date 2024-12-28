using CourseApp.Application.ResultDto;
using System.Security.Claims;

namespace CourseApp.API.Helpers;

public static class ClaimHelper
{
    public static Guid GetUserId(ClaimsPrincipal claims)
    {
        var userIdClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
            throw new UnauthorizedAccessException();

        var userId = Guid.Parse(userIdClaim.Value);
        return userId;
    }
}
