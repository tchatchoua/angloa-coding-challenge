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

public class TradesControllerTests
{
    private readonly TradesController _controller;
    private readonly Mock<ITradeService> _mockTradeService = new();

    public TradesControllerTests()
    {
        _controller = new TradesController(_mockTradeService.Object);
    }

    [Fact]
    public async Task Given_GetWithValidCommodityId_When_FetchingTrades_Then_ReturnOkStatusCode()
    {
        // Arrange
        var commodityId = 2;
        _mockTradeService.Setup(s =>
                s.GetByCommodityIdAsync(It.Is<int>(id => id == commodityId), It.IsAny<CancellationToken>()))
            .ReturnsAsync(() => new List<TradeDto>());

        // Act
        var response = await _controller.Get(commodityId, CancellationToken.None);

        // Assert
        Assert.IsType<OkObjectResult>(response);
    }
}