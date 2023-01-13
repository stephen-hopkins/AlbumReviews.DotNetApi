namespace AlbumReviews.DotNetApi.Dtos;

public class AlbumReviewDto
{
    public long Id { get; set; }
    public string Title { get; set; } = "";
    public string ReviewText { get; set; } = "";
    public string AuthorUserId { get; set; } = "";
    public long AlbumId { get; set; }
}