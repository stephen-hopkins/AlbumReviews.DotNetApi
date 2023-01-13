namespace AlbumReviews.DotNetApi.Models;

public class Auditable
{
    public long Id { get; set; }
    public DateTime CreatedDateTimeUtc { get; set; }
    public DateTime UpdatedDateTimeUtc { get; set; }
    public string LastUpdatedByUserId { get; set; } = "";
}