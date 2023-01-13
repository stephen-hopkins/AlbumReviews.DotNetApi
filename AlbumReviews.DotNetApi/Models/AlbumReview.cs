namespace AlbumReviews.DotNetApi.Models;

public class AlbumReview : Auditable
{
    public string Title { get; set; } = "";
    public string ReviewText { get; set; } = "";
    public string AuthorUserId { get; set; } = "";
    
    public long AlbumId { get; set; }
    public Album? Album { get; set; }
}