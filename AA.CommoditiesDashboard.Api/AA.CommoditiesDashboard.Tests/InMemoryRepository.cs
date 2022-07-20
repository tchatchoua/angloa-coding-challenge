using System.Collections.Generic;
using AA.CommoditiesDashboard.DataAccess;
using AA.CommoditiesDashboard.DataAccess.Repositories;

namespace AA.CommoditiesDashboard.Tests;

public class InMemoryRepository<T> : Repository<T> where T : class
{
    private readonly IUnitOfWork _unitOfWork;

    public InMemoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Add(T entity)
    {
        _unitOfWork.Context.Add(entity);
    }

    public void AddRange(IEnumerable<T> entities)
    {
        _unitOfWork.Context.AddRange(entities);
    }

    public void SaveChanges()
    {
        _unitOfWork.Context.SaveChanges();
    }
}