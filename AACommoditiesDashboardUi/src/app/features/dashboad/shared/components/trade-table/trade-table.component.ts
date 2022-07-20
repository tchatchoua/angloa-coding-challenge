import { Component, Input } from "@angular/core";
import { Trade } from "src/app/models";

@Component({
    selector:'app-trade-table',
    templateUrl:'trade-table.component.html',
    styleUrls:['trade-table.component.scss']
})
export class TradeTableComponent {

    public displayedColumns: string[] = ['date', 'contract', 'price', 'position','newTradeAction','pnlDaily'];

    @Input() trades!:Trade[];
}