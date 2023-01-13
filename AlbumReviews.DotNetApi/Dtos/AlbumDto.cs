namespace AlbumReviews.DotNetApi.Dtos;

public class AlbumDto
{
    public long Id { get; set; }
    public string Name { get; set; } = "";
    public DateTime ReleaseDate { get; set; }
    public long ArtistId { get; set; }
}