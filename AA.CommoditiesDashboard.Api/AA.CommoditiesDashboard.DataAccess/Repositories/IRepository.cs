using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.DataAccess.Repositories;

public interface IRepository<T> where T : class
{
    Task<IList<T>> GetAsync(CancellationToken cancellationToken);
    Task<IList<T>> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
    Task<T?> SingleAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
    Task AddAsync(T entity, CancellationToken cancellationToken);
    Task DeleteAsync(T entity, CancellationToken cancellationToken);
    Task UpdateAsync(T entity, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}