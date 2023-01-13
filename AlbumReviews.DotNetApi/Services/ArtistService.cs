using AlbumReviews.DotNetApi.Dtos;
using AlbumReviews.DotNetApi.Repositories;
using AlbumReviews.DotNetApi.Transformations;

namespace AlbumReviews.DotNetApi.Services;

public class ArtistService : IArtistService
{
    private readonly IArtistRepository _repo;

    public ArtistService(IArtistRepository repo)
    {
        this._repo = repo;
    }
    
    public async Task<List<ArtistDto>> SearchByName(string artistName)
    {
        var results = await _repo.SearchByName(artistName);
        return results.Select(a => a.ToDto()).ToList();
    }

    public async Task<ArtistDto> Add(ArtistDto dto, string userId)
    {
        var entity = dto.ToEntity();
        await _repo.Insert(entity, userId);
        return entity.ToDto();
    }
}