using System.ComponentModel.DataAnnotations.Schema;

namespace AA.CommoditiesDashboard.DataAccess.Entities;

[Table("Model")]
public class Model
{
    public int Id { get; set; }
    public string Name { get; set; }
}