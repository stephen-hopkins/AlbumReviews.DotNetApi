using AlbumReviews.DotNetApi.Dtos;

namespace AlbumReviews.DotNetApi.Services;

public interface IAlbumReviewService
{
    Task<AlbumReviewDto> AddAlbumReview(AlbumReviewDto albumReviewDto, string userId);
    Task<List<AlbumReviewDto>> GetOwnAlbumReviews(string userId);
    Task<List<AlbumReviewDto>> GetReviewsForAlbum(long albumId);
}