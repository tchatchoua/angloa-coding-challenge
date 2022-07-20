using AA.CommoditiesDashboard.DataAccess.Entities;
using AA.CommoditiesDashboard.DataAccess.Repositories;
using AA.CommoditiesDashboard.Domain.Dtos;

namespace AA.CommoditiesDashboard.Domain.Services;

public class TradeService : ITradeService
{
    private readonly IRepository<Trade> _repository;

    public TradeService(IRepository<Trade> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TradeDto>> GetByCommodityIdAsync(int commodityId, CancellationToken cancellationToken)
    {
        var trades = await _repository.GetAsync(t => t.CommodityId == commodityId, cancellationToken);

        return trades.Select(t => new TradeDto
        {
            Id = t.Id,
            CommodityId = t.CommodityId,
            Date = t.Date,
            Contract = t.Contract,
            Price = t.Price,
            Position = t.Position,
            NewTradeAction = t.NewTradeAction,
            PnlDaily = t.PnlDaily
        });
    }
}