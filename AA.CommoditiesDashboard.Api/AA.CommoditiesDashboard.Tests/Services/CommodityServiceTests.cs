using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AA.CommoditiesDashboard.DataAccess.Entities;
using AA.CommoditiesDashboard.Domain.Dtos;
using AA.CommoditiesDashboard.Domain.Services;
using AA.CommoditiesDashboard.Tests.Data;
using FluentAssertions;
using Xunit;

namespace AA.CommoditiesDashboard.Tests.Services;

public class CommodityServiceTests : BaseServiceTests
{
    private readonly ICommodityService _commodityService;

    public CommodityServiceTests()
    {
        var repository = new InMemoryRepository<Commodity>(UnitOfWork);

        _commodityService = new CommodityService(repository);

        repository.AddRange(Commodities.All);

        repository.SaveChanges();
    }

    [Fact]
    public async Task Given_GetAllAsync_When_FetchingCommodities_Then_ReturnAllCommodities()
    {
        // Arrange
        var expectedCount = 3;

        // Act
        var commodities = await _commodityService.GetAllAsync(CancellationToken.None);

        // Assert
        Assert.Equal(expectedCount, commodities.Count());
    }

    [Fact]
    public async Task Given_GetByIdAsync_When_FetchingCommodity_Then_ReturnValidCommodity()
    {
        // Arrange
        var commodityId = 3;

        var expectedCommodity = new CommodityDto
        {
            Id = 3,
            Name = "Coffee"
        };

        // Act
        var commodity = await _commodityService.GetByIdAsync(commodityId, CancellationToken.None);

        // Assert
        commodity.Should().BeEquivalentTo(expectedCommodity);
    }

    [Fact]
    public async Task Given_GetByIdAsyncWithInvalidId_When_FetchingCommodity_Then_ReturnNull()
    {
        // Arrange
        var commodityId = 5;

        // Act
        var commodity = await _commodityService.GetByIdAsync(commodityId, CancellationToken.None);

        // Assert
        Assert.Null(commodity);
    }

    [Fact]
    public async Task Given_GetByModelIdAsync_When_FetchingCommodities_Then_ReturnAllModelCommodities()
    {
        // Arrange
        var modelId = 1;
        var expectedCommodities = new List<CommodityDto>
        {
            new() {Id = 1, Name = "Gold"},
            new() {Id = 2, Name = "Oil"}
        };

        // Act
        var commodities = await _commodityService.GetByModelIdAsync(modelId, CancellationToken.None);

        // Assert
        commodities.Should().BeEquivalentTo(expectedCommodities);
    }
}