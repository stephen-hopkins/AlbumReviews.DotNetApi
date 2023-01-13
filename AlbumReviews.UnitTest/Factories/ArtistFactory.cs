using AlbumReviews.DotNetApi.Dtos;
using Bogus;

namespace AlbumReviews.UnitTest.Factories;

public static class ArtistFactory
{
    public static readonly Faker<ArtistDto> ArtistDto = new Faker<ArtistDto>()
        .Rules((f, o) =>
        {
            o.Name = f.Name.FullName();
            o.Albums = AlbumDto.Generate(5);
        });

    private static readonly Faker<AlbumDto> AlbumDto = new Faker<AlbumDto>()
        .Rules((f, o) =>
        {
            o.Name = f.Lorem.Slug();
            o.ReleaseDate = f.Date.Past();
        });
}