//using System.Security.Claims;

//namespace CourseApp.Application.Common;

//public abstract record AuthorizedRequest
//{
//    private readonly ClaimsPrincipal _claims;

//    public ClaimsPrincipal Claims
//    {
//        get { return this._claims; }
//    }

//    protected AuthorizedRequest(ClaimsPrincipal claims)
//    {
//        this._claims = claims;
//    }

//    public Guid GetUserId()
//    {
//        Claim? idClaim = this.Claims.FindFirst(ClaimTypes.NameIdentifier);
//        if (idClaim == null)
//        {
//            throw new UnauthorizedAccessException("Id claim not found in token!");
//        }

//        return Guid.Parse(idClaim.Value);
//    }

//    public string GetClaimValue(string claimType)
//    {
//        Claim? claim = this.Claims.FindFirst(claimType);
//        if (claim == null)
//        {
//            throw new UnauthorizedAccessException($"{claim} claim not found in token!");
//        }

//        return claim.Value;
//    }
//}