using AlbumReviews.DotNetApi.Dtos;
using AlbumReviews.DotNetApi.Models;

namespace AlbumReviews.DotNetApi.Transformations;

public static class AlbumTransformations
{
    public static AlbumDto ToDto(this Album entity)
    {
        return new AlbumDto
        {
            Id = entity.Id,
            Name = entity.Name,
            ReleaseDate = entity.ReleaseDate
        };
    }

    public static Album ToEntity(this AlbumDto dto)
    {
        return new Album
        {
            Id = dto.Id,
            Name = dto.Name,
            ReleaseDate = dto.ReleaseDate
        };
    }
}