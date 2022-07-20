using AA.CommoditiesDashboard.Domain.Dtos;

namespace AA.CommoditiesDashboard.Domain.Services;

public interface ICommodityService
{
    Task<IEnumerable<CommodityDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<CommodityDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<CommodityDto>> GetByModelIdAsync(int modelId, CancellationToken cancellationToken);
}