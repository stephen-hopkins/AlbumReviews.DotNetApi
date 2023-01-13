using AlbumReviews.DotNetApi.Models;

namespace AlbumReviews.DotNetApi.Repositories;

public interface IArtistRepository : IAuditableRepository<Artist>
{
    Task<List<Artist>> SearchByName(string artistName);
}