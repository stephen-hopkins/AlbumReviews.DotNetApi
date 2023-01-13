namespace AlbumReviews.DotNetApi.Models;

public class Album : Auditable
{
    public string Name { get; set; } = "";
    public DateTime ReleaseDate { get; set; }
    
    public long ArtistId { get; set; }
    public Artist? Artist { get; set; }
    public List<AlbumReview> AlbumReviews { get; set; } = new List<AlbumReview>();
}