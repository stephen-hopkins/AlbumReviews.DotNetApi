using AlbumReviews.DotNetApi.Models;

namespace AlbumReviews.DotNetApi.Repositories;

public interface IAlbumReviewRepository : IAuditableRepository<AlbumReview>
{
    Task<List<AlbumReview>> GetByUserId(string userId);
    Task<List<AlbumReview>> GetByAlbumId(long albumId);
}