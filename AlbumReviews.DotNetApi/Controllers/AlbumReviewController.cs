using AlbumReviews.DotNetApi.Dtos;
using AlbumReviews.DotNetApi.Helpers;
using AlbumReviews.DotNetApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace AlbumReviews.DotNetApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
public class AlbumReviewController : BaseController
{
    private readonly ILogger<AlbumReviewController> _logger;
    private readonly IAlbumReviewService _service;

    public AlbumReviewController(ILogger<AlbumReviewController> logger, IAlbumReviewService service)
    {
        _logger = logger;
        _service = service;
    }
    
    /// <summary>
    /// Retrieves a list of reviews the user has written
    /// </summary>
    /// <returns>List of reviews the user has written</returns>
    [HttpGet("own")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<List<AlbumReviewDto>>> GetOwn()
    {
        var userId = GetUserId();
        var results = await _service.GetOwnAlbumReviews(userId);
        return results.Any() ? 
            results : 
            NoContent();
    }
    
    /// <summary>
    /// Retrieves all the reviews for an album
    /// </summary>
    /// <param name="albumId">Id of album</param>
    /// <returns>List of reviews for album</returns>
    [HttpGet("album")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<List<AlbumReviewDto>>> GetOwn(long albumId)
    {
        var results = await _service.GetReviewsForAlbum(albumId);
        return results.Any() ? 
            results : 
            NoContent();
    }
    
    /// <summary>
    /// Add a new album review
    /// </summary>
    /// <param name="dto">New album review</param>
    /// <returns>Created album review</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AlbumReviewDto>> Add([FromBody]AlbumReviewDto dto)
    {
        try
        {
            var userId = GetUserId();
            var created = await _service.AddAlbumReview(dto, userId);
            return created;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error saving new album review");
            return BadRequest();
        }
    }
}