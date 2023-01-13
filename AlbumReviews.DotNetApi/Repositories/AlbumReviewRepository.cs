using AlbumReviews.DotNetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AlbumReviews.DotNetApi.Repositories;

public class AlbumReviewRepository : AuditableRepository<AlbumReview>, IAlbumReviewRepository
{
    public AlbumReviewRepository(ApplicationContext context) : base(context)
    {
    }

    public Task<List<AlbumReview>> GetByUserId(string userId)
    {
        return entities
            .Where(e => e.AuthorUserId == userId)
            .ToListAsync();
    }

    public Task<List<AlbumReview>> GetByAlbumId(long albumId)
    {
        return entities
            .Where(ar => ar.AlbumId == albumId)
            .ToListAsync();
    }
}