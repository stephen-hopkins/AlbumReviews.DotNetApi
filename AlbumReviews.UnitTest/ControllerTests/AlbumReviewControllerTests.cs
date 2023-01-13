using AlbumReviews.DotNetApi.Controllers;
using AlbumReviews.DotNetApi.Services;
using AlbumReviews.UnitTest.Factories;
using AlbumReviews.UnitTest.Helpers;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;

namespace AlbumReviews.UnitTest;

public class AlbumReviewControllerTests : SqlLiteContext
{
    private readonly AlbumReviewController _controller;

    public AlbumReviewControllerTests()
    {
        _controller = ControllerFactories.AlbumReviewController(CreateContext(), "AlbumReviewTests");
    }

    [Fact]
    public async Task GetOwnReviewsHappyPath()
    {
        var artistDto = ArtistFactory.ArtistDto.Generate();
        var req = Mock.Of<HttpRequest>();
        var artistController = ControllerFactories.ArtistController(CreateContext(), "AlbumReviewTests");
        var createdArtist = await artistController.Add(req, artistDto);
        var review = AlbumReviewFactory.AlbumReviewDto.Generate();
        review.AlbumId = createdArtist.Value!.Albums[0].Id;

        var addResult = await _controller.Add(req, review);
        addResult.Value.Should().NotBeNull();
        addResult.Value!.Should().BeEquivalentTo(review, options => 
            options.Excluding(r => r.Id).Excluding(r => r.AuthorUserId));

        var ownResults = await _controller.GetOwn(req);
        ownResults.Value.Should().NotBeNull();
        ownResults.Value.Should().HaveCount(1);
        ownResults.Value![0].Should().BeEquivalentTo(addResult.Value);
    }
}