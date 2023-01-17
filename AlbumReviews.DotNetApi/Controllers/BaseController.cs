using AlbumReviews.DotNetApi.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace AlbumReviews.DotNetApi.Controllers;

public class BaseController : ControllerBase
{
    public IUserClaims UserClaims { get; set; }

    public BaseController()
    {
        UserClaims = new UserClaims();
    }

    protected string GetUserId()
    {
        return UserClaims.GetUserId(HttpContext?.Request);
    }
}