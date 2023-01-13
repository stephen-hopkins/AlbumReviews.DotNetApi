using AlbumReviews.DotNetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AlbumReviews.DotNetApi.Repositories;

public class ArtistRepository : AuditableRepository<Artist>, IArtistRepository
{
    public ArtistRepository(ApplicationContext context) : base(context)
    {
    }

    public Task<List<Artist>> SearchByName(string artistName)
    {
        return entities
            .Where(a => a.Name.Contains(artistName))
            .Include(a => a.Albums)
            .ToListAsync();
    }
}