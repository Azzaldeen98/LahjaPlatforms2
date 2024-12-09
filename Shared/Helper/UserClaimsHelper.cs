using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Helper;

public interface IUserClaimsHelper
{
    string UserId { get; }
    string UserRole { get; }
    string Email { get; }
    public string AccessTokenHash { get; }
    public string AccessToken { get; }
    public string RefreshToken { get; }

}

public class UserClaimsHelper : IUserClaimsHelper
{

    public UserClaimsHelper(IHttpContextAccessor httpContextAccessor)
    {
        UserId = httpContextAccessor?.HttpContext?.User?.GetClaim("id") ?? "";
        UserRole = httpContextAccessor?.HttpContext?.User?.GetClaim(ClaimTypes.Role)??"";
        Email = httpContextAccessor?.HttpContext?.User?.GetClaim("email")??"";

        AccessToken = httpContextAccessor?.HttpContext?.User?.GetClaim("accessToken")??"";
        AccessTokenHash = httpContextAccessor?.HttpContext?.User?.GetClaim("accessTokenHash")??"";
        RefreshToken = httpContextAccessor?.HttpContext?.User?.GetClaim("refreshToken")??"";

    }

    public string UserId { get; private set; }

    public string UserRole { get; private set; }

    public string Email { get; private set; }
    public string AccessToken { get; private set; }
    public string AccessTokenHash { get; private set; }
    public string RefreshToken { get; private set; }


}
