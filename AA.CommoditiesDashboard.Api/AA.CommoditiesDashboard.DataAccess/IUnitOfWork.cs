using System;
using Microsoft.EntityFrameworkCore;

namespace AA.CommoditiesDashboard.DataAccess;

public interface IUnitOfWork : IDisposable
{
    DbContext Context { get; }
    void Commit();
}