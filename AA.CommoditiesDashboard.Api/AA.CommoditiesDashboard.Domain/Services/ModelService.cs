using AA.CommoditiesDashboard.DataAccess.Entities;
using AA.CommoditiesDashboard.DataAccess.Repositories;
using AA.CommoditiesDashboard.Domain.Dtos;

namespace AA.CommoditiesDashboard.Domain.Services;

public class ModelService : IModelService
{
    private readonly IRepository<Model> _repository;

    public ModelService(IRepository<Model> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ModelDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var models = await _repository.GetAsync(cancellationToken);

        return models.Select(m => new ModelDto {Id = m.Id, Name = m.Name});
    }

    public async Task<ModelDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var model = await _repository.SingleAsync(m => m.Id == id, cancellationToken);

        if (model == null) return null;

        return new ModelDto
        {
            Id = model.Id,
            Name = model.Name
        };
    }
}