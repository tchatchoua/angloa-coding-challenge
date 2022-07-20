using AA.CommoditiesDashboard.Domain.Dtos;

namespace AA.CommoditiesDashboard.Domain.Services;

public interface ITradeService
{
    Task<IEnumerable<TradeDto>> GetByCommodityIdAsync(int commodityId, CancellationToken cancellationToken);
}