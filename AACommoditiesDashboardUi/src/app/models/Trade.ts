export interface Trade {
    id: number;
    commodityId: number;
    date: string;
    contract: string;
    price: number;
    position: number;
    newTradeAction: number;
    pnlDaily: number;
}