namespace AlbumReviews.DotNetApi.Helpers;

public interface IUserClaims
{
    string GetUserId(HttpRequest? req);
}