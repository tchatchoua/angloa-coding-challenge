using System;
using AA.CommoditiesDashboard.DataAccess.Entities;

namespace AA.CommoditiesDashboard.Tests.Data;

public class Trades
{
    public static Trade Create(int id, int commodityId, DateTime date, string contract, int position,
        int newTradeAction, decimal price, decimal pnlDaily)
    {
        return new Trade
        {
            Id = id,
            CommodityId = commodityId,
            Date = date,
            Contract = contract,
            Position = position,
            NewTradeAction = newTradeAction,
            Price = price,
            PnlDaily = pnlDaily
        };
    }
}