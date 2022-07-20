using AA.CommoditiesDashboard.DataAccess;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace AA.CommoditiesDashboard.Tests.Services;

public abstract class BaseServiceTests
{
    private const string InMemoryConnectionString = "DataSource=:memory:";
    private IUnitOfWork _unitOfWork;

    protected IUnitOfWork UnitOfWork
    {
        get
        {
            if (_unitOfWork != null) return _unitOfWork;
            var connection = new SqliteConnection(InMemoryConnectionString);
            connection.Open();
            var options = new DbContextOptionsBuilder<CommodityContext>()
                .UseSqlite(connection)
                .Options;


            var dbContext = new CommodityContext(options);
            dbContext.Database.EnsureCreated();
            _unitOfWork = new UnitOfWork(dbContext);

            return _unitOfWork;
        }
    }
}