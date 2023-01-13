using AlbumReviews.DotNetApi.Controllers;
using AlbumReviews.DotNetApi.Helpers;
using AlbumReviews.DotNetApi.Models;
using AlbumReviews.DotNetApi.Repositories;
using AlbumReviews.DotNetApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;

namespace AlbumReviews.UnitTest.Factories;

public static class ControllerFactories
{
    public static ArtistController ArtistController(ApplicationContext context, string userId)
    {
        var logger = Mock.Of<ILogger<ArtistController>>();
        var repo = new ArtistRepository(context);
        var service = new ArtistService(repo);
        var controller = new ArtistController(logger, service);

        var userClaimsMock = new Mock<IUserClaims>();
        userClaimsMock.Setup(uc => uc.GetUserId(It.IsAny<HttpRequest>())).Returns(userId);

        controller.UserClaims = userClaimsMock.Object;
        return controller;
    }

    public static AlbumReviewController AlbumReviewController(ApplicationContext context, string userId)
    {
        var logger = Mock.Of<ILogger<AlbumReviewController>>();
        var repo = new AlbumReviewRepository(context);
        var service = new AlbumReviewService(repo);
        var controller = new AlbumReviewController(logger, service);
        
        var userClaimsMock = new Mock<IUserClaims>();
        userClaimsMock.Setup(uc => uc.GetUserId(It.IsAny<HttpRequest>())).Returns(userId);

        controller.UserClaims = userClaimsMock.Object;
        return controller;
    }
}