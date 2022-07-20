using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AA.CommoditiesDashboard.DataAccess.Entities;
using AA.CommoditiesDashboard.Domain.Dtos;
using AA.CommoditiesDashboard.Domain.Services;
using AA.CommoditiesDashboard.Tests.Data;
using FluentAssertions;
using Xunit;

namespace AA.CommoditiesDashboard.Tests.Services;

public class TradeServiceTests : BaseServiceTests
{
    private readonly DateTime _currentDateTime = DateTime.Now;
    private readonly ITradeService _tradeService;

    public TradeServiceTests()
    {
        var repository = new InMemoryRepository<Trade>(UnitOfWork);

        _tradeService = new TradeService(repository);

        var trade1 = Trades.Create(1, 1, _currentDateTime, "MAR 18", 1, 0, 1000M, 15183.69M);
        var trade2 = Trades.Create(2, 1, _currentDateTime, "MAR 18", 1, 0, 1500M, 25183.69M);
        var trade3 = Trades.Create(3, 2, _currentDateTime, "JUL 19", 1, 0, 2000M, 35183.69M);


        repository.AddRange(new List<Trade> {trade1, trade2, trade3});

        repository.SaveChanges();
    }

    [Fact]
    public async Task Given_GetByCommodityIdAsync_When_FetchingTradeData_Then_ReturnAllCommodityTrades()
    {
        // Arrange

        var commodityId = 1;

        var expectedTrades = new List<TradeDto>
        {
            new()
            {
                Id = 1,
                CommodityId = 1,
                Date = _currentDateTime,
                Contract = "MAR 18",
                Position = 1,
                NewTradeAction = 0,
                Price = 1000M,
                PnlDaily = 15183.69M
            },
            new()
            {
                Id = 2,
                CommodityId = 1,
                Date = _currentDateTime,
                Contract = "MAR 18",
                Position = 1,
                NewTradeAction = 0,
                Price = 1500M,
                PnlDaily = 25183.69M
            }
        };

        // Act
        var trades = await _tradeService.GetByCommodityIdAsync(commodityId, CancellationToken.None);

        // Assert
        trades.Should().BeEquivalentTo(expectedTrades);
    }
}