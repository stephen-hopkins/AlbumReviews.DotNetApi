using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AlbumReviews.DotNetApi.Helpers;

/// <summary>
/// This is an instantiated class rather than extension method to enable mocking for unit testing
/// </summary>
public class UserClaims : IUserClaims
{
    private static string UserIdClaimName = "sub";

    public string GetUserId(HttpRequest req)
    {
        var trimmed = req.Headers.Authorization.ToString().Replace("Bearer ", String.Empty);
        if (!string.IsNullOrEmpty(trimmed))
        {
            var token = new JwtSecurityTokenHandler().ReadJwtToken(trimmed);
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(token.Claims));
            var claim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == UserIdClaimName);
            if (claim != null && !string.IsNullOrEmpty(claim.Value))
            {
                return claim.Value;
            }
        }

        throw new Exception("UserId claim missing");
    }
}