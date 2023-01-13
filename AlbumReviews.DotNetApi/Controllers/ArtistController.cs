using AlbumReviews.DotNetApi.Dtos;
using AlbumReviews.DotNetApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace AlbumReviews.DotNetApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
public class ArtistController : BaseController
{
    private readonly ILogger<ArtistController> _logger;
    private readonly IArtistService _service;

    public ArtistController(ILogger<ArtistController> logger, IArtistService service)
    {
        _logger = logger;
        _service = service;
    }

    /// <summary>
    /// Retrieves a list of artists whose names contain the search string
    /// </summary>
    /// <param name="searchString">String to search by, must not be empty or whitespace</param>
    /// <returns>List of artists whose name matches</returns>
    [HttpGet("search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<ArtistDto>>> SearchByName(string searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
        {
            return BadRequest();
        }
        
        var results = await _service.SearchByName(searchString);
        return results.Any() ? 
            results : 
            NoContent();
    }
    
    /// <summary>
    /// Add a new artist
    /// </summary>
    /// <param name="dto">New artist</param>
    /// <returns>Created artist</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ArtistDto>> Add(HttpRequest req, ArtistDto dto)
    {
        try
        {
            var userId = UserClaims.GetUserId(req);
            var created = await _service.Add(dto, userId);
            return created;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error saving new Artist");
            return BadRequest();
        }
    }


}