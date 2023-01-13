using AlbumReviews.DotNetApi.Dtos;
using Bogus;

namespace AlbumReviews.UnitTest.Factories;

public static class AlbumReviewFactory
{
    public static readonly Faker<AlbumReviewDto> AlbumReviewDto = new Faker<AlbumReviewDto>()
        .Rules((f, o) =>
        {
            o.Title = f.Lorem.Sentence();
            o.ReviewText = f.Rant.Review();
        });
}