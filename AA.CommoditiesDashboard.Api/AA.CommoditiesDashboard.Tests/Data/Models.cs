using System.Collections.Generic;
using AA.CommoditiesDashboard.DataAccess.Entities;

namespace AA.CommoditiesDashboard.Tests.Data;

public class Models
{
    public static IEnumerable<Model> All => new List<Model>
    {
        new() {Id = 1, Name = "Model1"},
        new() {Id = 2, Name = "Model2"},
        new() {Id = 3, Name = "Model3"},
        new() {Id = 4, Name = "Model4"},
        new() {Id = 5, Name = "Model5"}
    };
}