namespace AlbumReviews.DotNetApi.Dtos;

public class ArtistDto
{
    public long Id { get; set; }
    public string Name { get; set; } = "";
    public List<AlbumDto> Albums { get; set; } = new List<AlbumDto>();
}