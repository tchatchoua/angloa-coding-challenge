using AA.CommoditiesDashboard.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AA.CommoditiesDashboard.DataAccess;

public class CommodityContext : DbContext
{
    public CommodityContext()
    {
    }

    public CommodityContext(DbContextOptions<CommodityContext> options) : base(options)
    {
    }

    public DbSet<Model> Models { get; set; }
    public DbSet<Commodity> Commodities { get; set; }
    public DbSet<Trade> Trades { get; set; }
}