import { ChangeDetectionStrategy, Component, OnInit } from "@angular/core";
import { Observable, Subject} from 'rxjs';
import { mergeMap,share, map } from 'rxjs/operators';
import { Commodity, Trade, TradeModel } from "src/app/models";
import { CommodityDataService } from "src/app/shared/services/commodity-data.service";
import { ModelDataService } from "src/app/shared/services/model-data.service";
import { TradeDataService } from "src/app/shared/services/trade-data.service";

@Component({
    selector: 'app-management-dashboard',
    templateUrl: 'management-dashboard.component.html',
    styleUrls: ['management-dashboard.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ManagementDasboardComponent implements OnInit {

    public models$!: Observable<TradeModel[]>;
    public commodities$!: Observable<Commodity[]>;
    public trades$!: Observable<Trade[]>;
    public pnlByContracts$!:Observable<{contract:string,totalPnlDaily:number}[]>

    private modelChanges$:Subject<number> = new Subject();
    private commodityChanges$:Subject<number> = new Subject();

    constructor(private modelDataService:ModelDataService,
        private commodityDataService:CommodityDataService,
        private tradeDataService:TradeDataService){}

    ngOnInit(): void {
        this.models$ = this.modelDataService.getAll();
        
        this.commodities$ = this.modelChanges$.pipe(
            mergeMap(modelId=> this.commodityDataService.getByModelId(modelId))
        )

        const trades$  = this.commodityChanges$.pipe(
            mergeMap(commodityId=> this.tradeDataService.getByCommodityId(commodityId)),
            share()
        )

        this.trades$ = trades$;

        this.pnlByContracts$ = trades$.pipe(map(trades=> trades.reduce((acc,trade)=> {
            acc[trade.contract] = acc[trade.contract]||0 + trade.pnlDaily;
            return acc;
        }, <{[key:string]:number}>{})),
        map(aggTrades=> {
           return Object.keys(aggTrades).map(key=> ({contract: key, totalPnlDaily: aggTrades[key]}))
        }));
    }

    public modelSelectionChange(modelId:number) {
        this.modelChanges$.next(modelId);
    }

    public commoditySelectionChange(commodityId:number) {
        this.commodityChanges$.next(commodityId);
    }
}