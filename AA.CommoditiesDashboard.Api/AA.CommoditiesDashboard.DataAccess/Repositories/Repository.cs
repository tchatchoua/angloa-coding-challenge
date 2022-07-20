using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AA.CommoditiesDashboard.DataAccess.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly IUnitOfWork _unitOfWork;

    public Repository(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public async Task<IList<T>> GetAsync(CancellationToken cancellationToken)
    {
        return await _unitOfWork.Context.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<IList<T>> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Context.Set<T>().Where(predicate).ToListAsync(cancellationToken);
    }

    public async Task<T?> SingleAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Context.Set<T>().Where(predicate).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        await Task.Run(() => _unitOfWork.Context.Set<T>(), cancellationToken);
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
    {
        await Task.Run(() =>
        {
            var existing = _unitOfWork.Context.Set<T>().Find(entity);
            if (existing != null) _unitOfWork.Context.Set<T>().Remove(existing);
        }, cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        await Task.Run(() =>
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Context.Set<T>().Attach(entity);
        }, cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await Task.Run(() => { _unitOfWork.Commit(); }, cancellationToken);
    }
}