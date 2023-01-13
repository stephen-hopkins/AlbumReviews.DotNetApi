using AlbumReviews.DotNetApi.Dtos;
using AlbumReviews.DotNetApi.Models;

namespace AlbumReviews.DotNetApi.Transformations;

public static class ArtistTransformations
{
    public static ArtistDto ToDto(this Artist entity)
    {
        return new ArtistDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Albums = entity.Albums.Select(album => album.ToDto()).ToList()
        };
    }

    public static Artist ToEntity(this ArtistDto dto)
    {
        return new Artist
        {
            Id = dto.Id,
            Name = dto.Name,
            Albums = dto.Albums.Select(album => album.ToEntity()).ToList()
        };
    }
}