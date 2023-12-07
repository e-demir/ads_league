using Ads_League.Business;
using Ads_League.Common;
using Ads_League.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

public class AdsLeagueControllerTests
{
    [Fact]
    public void MakeDrawing_WithValidRequest_ReturnsOkResult()
    {
        // Arrange
        var businessLayerMock = new Mock<IBusinessLayer>();
        var controller = new AdsLeagueController(businessLayerMock.Object);

        var validRequest = new MakeDrawingRequestModel
        {
            Name = "Emrullah",
            SurName = "Demir",
            GroupCount = 4
        };

        // Act
        var result = controller.MakeDrawing(validRequest);

        // Assert
        Assert.IsType<OkObjectResult>(result);

    }

    [Fact]
    public void MakeDrawing_WithInvalidGroupCount_ReturnsBadRequest()
    {
        // Arrange
        var businessLayerMock = new Mock<IBusinessLayer>();
        var controller = new AdsLeagueController(businessLayerMock.Object);

        var invalidRequest = new MakeDrawingRequestModel
        {
            Name = "Emrullah",
            SurName = "Demir",
            GroupCount = 3
        };

        // Act
        var result = controller.MakeDrawing(invalidRequest);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Group number must be 4 or 8.", (result as BadRequestObjectResult)?.Value);
    }
}
