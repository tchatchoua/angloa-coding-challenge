using System.ComponentModel.DataAnnotations.Schema;

namespace AA.CommoditiesDashboard.DataAccess.Entities;

[Table("Commodity")]
public class Commodity
{
    public int Id { get; set; }
    public int ModelId { get; set; }
    public string Name { get; set; }
}