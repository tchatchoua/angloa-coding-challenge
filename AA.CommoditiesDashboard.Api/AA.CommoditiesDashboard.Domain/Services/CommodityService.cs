using AA.CommoditiesDashboard.DataAccess.Entities;
using AA.CommoditiesDashboard.DataAccess.Repositories;
using AA.CommoditiesDashboard.Domain.Dtos;

namespace AA.CommoditiesDashboard.Domain.Services;

public class CommodityService : ICommodityService
{
    private readonly IRepository<Commodity> _repository;

    public CommodityService(IRepository<Commodity> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CommodityDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var commodities = await _repository.GetAsync(cancellationToken);

        return commodities.Select(c => new CommodityDto {Id = c.Id, Name = c.Name});
    }

    public async Task<CommodityDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var commodity = await _repository.SingleAsync(m => m.Id == id, cancellationToken);

        if (commodity == null) return null;

        return new CommodityDto
        {
            Id = commodity.Id,
            Name = commodity.Name
        };
    }

    public async Task<IEnumerable<CommodityDto>> GetByModelIdAsync(int modelId, CancellationToken cancellationToken)
    {
        var commodities = await _repository.GetAsync(c => c.ModelId == modelId, cancellationToken);

        return commodities.Select(c => new CommodityDto {Id = c.Id, Name = c.Name});
    }
}