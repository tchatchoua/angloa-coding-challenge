using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AA.CommoditiesDashboard.Api.Controllers;
using AA.CommoditiesDashboard.Domain.Dtos;
using AA.CommoditiesDashboard.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace AA.CommoditiesDashboard.Tests.Controllers;

public class CommoditiesControllerTests
{
    private readonly CommoditiesController _controller;
    private readonly Mock<ICommodityService> _mockCommodityService = new();

    public CommoditiesControllerTests()
    {
        _controller = new CommoditiesController(_mockCommodityService.Object);
    }

    [Fact]
    public async Task Given_Get_When_FetchingCommodities_Then_ReturnOkStatusCode()
    {
        // Arrange
        _mockCommodityService.Setup(s => s.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(() => new List<CommodityDto>());

        // Act
        var response = await _controller.Get(CancellationToken.None);

        // Assert
        Assert.IsType<OkObjectResult>(response);
    }

    [Fact]
    public async Task Given_GetWithModelId_When_FetchingCommodies_Then_ReturnOkStatusResponse()
    {
        // Arrange
        var modelId = 1;
        _mockCommodityService.Setup(s => s.GetByModelIdAsync(modelId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(() => new List<CommodityDto>());

        // Act
        var response = await _controller.Get(modelId, CancellationToken.None);

        // Assert
        Assert.IsType<OkObjectResult>(response);
    }
}