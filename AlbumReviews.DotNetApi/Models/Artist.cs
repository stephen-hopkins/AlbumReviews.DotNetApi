namespace AlbumReviews.DotNetApi.Models;

public class Artist : Auditable
{
    public string Name { get; set; } = "";

    public List<Album> Albums { get; set; } = new List<Album>();
}