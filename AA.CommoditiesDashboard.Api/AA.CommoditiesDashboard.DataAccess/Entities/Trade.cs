using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AA.CommoditiesDashboard.DataAccess.Entities;

[Table("CommodityData")]
public class Trade
{
    public int Id { get; set; }
    public int CommodityId { get; set; }
    public DateTime Date { get; set; }
    public string? Contract { get; set; }
    public decimal Price { get; set; }
    public int Position { get; set; }
    public int NewTradeAction { get; set; }
    public decimal PnlDaily { get; set; }
}