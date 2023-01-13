using AlbumReviews.DotNetApi.Dtos;
using AlbumReviews.DotNetApi.Repositories;
using AlbumReviews.DotNetApi.Transformations;

namespace AlbumReviews.DotNetApi.Services;

public class AlbumReviewService : IAlbumReviewService
{
    private readonly IAlbumReviewRepository _repo;

    public AlbumReviewService(IAlbumReviewRepository repo)
    {
        _repo = repo;
    }

    public async Task<AlbumReviewDto> AddAlbumReview(AlbumReviewDto albumReviewDto, string userId)
    {
        var entity = albumReviewDto.ToEntity(userId);
        await _repo.Insert(entity, userId);
        return entity.ToDto();
    }

    public async Task<List<AlbumReviewDto>> GetOwnAlbumReviews(string userId)
    {
        var reviews = await _repo.GetByUserId(userId);
        return reviews.Select(ar => ar.ToDto()).ToList();
    }

    public async Task<List<AlbumReviewDto>> GetReviewsForAlbum(long albumId)
    {
        var reviews = await _repo.GetByAlbumId(albumId);
        return reviews.Select(ar => ar.ToDto()).ToList();
    }
}