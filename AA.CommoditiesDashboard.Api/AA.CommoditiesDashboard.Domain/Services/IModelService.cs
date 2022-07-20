using AA.CommoditiesDashboard.Domain.Dtos;

namespace AA.CommoditiesDashboard.Domain.Services;

public interface IModelService
{
    Task<IEnumerable<ModelDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<ModelDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
}