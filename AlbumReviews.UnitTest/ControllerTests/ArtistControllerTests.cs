using AlbumReviews.DotNetApi.Controllers;
using AlbumReviews.UnitTest.Factories;
using AlbumReviews.UnitTest.Helpers;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;

namespace AlbumReviews.UnitTest.ControllerTests;

public class ArtistControllerTests : SqlLiteContext
{
    private readonly ArtistController _controller;
    
    public ArtistControllerTests()
    {
        _controller = ControllerFactories.ArtistController(CreateContext(), "ArtistControllerTests");
    }
    
    [Fact]
    public async Task InsertAndSearchHappyPath()
    {
        var artistDto = ArtistFactory.ArtistDto.Generate();
        artistDto.Name = "Aphex Twin";

        var addResult = await _controller.Add(artistDto);

        addResult.Should().NotBeNull();
        addResult.Value.Should().BeEquivalentTo(artistDto, options => options
            .Excluding(a => a.Id)
            .For(a => a.Albums).Exclude(al => al.Id));

        var searchResult = await _controller.SearchByName("hex");

        searchResult.Value.Should().NotBeNull();
        searchResult.Value.Should().HaveCount(1);
        searchResult.Value!.FirstOrDefault()!.Should().BeEquivalentTo(artistDto, options => options
            .Excluding(a => a.Id)
            .For(a => a.Albums).Exclude(al => al.Id));
    }
}