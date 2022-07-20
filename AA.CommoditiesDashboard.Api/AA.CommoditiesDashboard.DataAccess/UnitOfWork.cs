using Microsoft.EntityFrameworkCore;

namespace AA.CommoditiesDashboard.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(DbContext context)
    {
        Context = context;
    }

    public DbContext Context { get; }

    public void Commit()
    {
        Context.SaveChanges();
    }

    public void Dispose()
    {
        Context.Dispose();
    }
}