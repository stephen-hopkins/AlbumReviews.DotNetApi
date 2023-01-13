using AlbumReviews.DotNetApi.Dtos;

namespace AlbumReviews.DotNetApi.Services;

public interface IArtistService
{
    Task<List<ArtistDto>> SearchByName(string artistName);
    Task<ArtistDto> Add(ArtistDto dto, string userId);
}