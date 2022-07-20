using System.Collections.Generic;
using AA.CommoditiesDashboard.DataAccess.Entities;

namespace AA.CommoditiesDashboard.Tests.Data;

public class Commodities
{
    public static IEnumerable<Commodity> All => new List<Commodity>
    {
        new() {Id = 1, ModelId = 1, Name = "Gold"},
        new() {Id = 2, ModelId = 1, Name = "Oil"},
        new() {Id = 3, ModelId = 2, Name = "Coffee"}
    };
}