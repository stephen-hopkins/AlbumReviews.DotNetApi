using AlbumReviews.DotNetApi.Dtos;
using AlbumReviews.DotNetApi.Models;

namespace AlbumReviews.DotNetApi.Transformations;

public static class AlbumReviewTransformations
{
    public static AlbumReview ToEntity(this AlbumReviewDto dto, string userId)
    {
        return new AlbumReview
        {
            Id = dto.Id,
            Title = dto.Title,
            ReviewText = dto.ReviewText,
            AuthorUserId = userId,
            AlbumId = dto.AlbumId
        };
    }

    public static AlbumReviewDto ToDto(this AlbumReview entity)
    {
        return new AlbumReviewDto
        {
            Id = entity.Id,
            Title = entity.Title,
            ReviewText = entity.ReviewText,
            AuthorUserId = entity.AuthorUserId,
            AlbumId = entity.AlbumId
        };
    }
}