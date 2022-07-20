import { ChangeDetectionStrategy, Component, OnInit } from "@angular/core";
import { Commodity, Trade, TradeModel } from "src/app/models";
import { Observable, Subject, BehaviorSubject} from 'rxjs';
import { mergeMap, tap} from 'rxjs/operators';
import { ModelDataService } from "src/app/shared/services/model-data.service";
import { CommodityDataService } from "src/app/shared/services/commodity-data.service";
import { TradeDataService } from "src/app/shared/services/trade-data.service";

@Component({
    selector: 'app-developers-dashboard',
    templateUrl: 'developers-dashboard.component.html',
    styleUrls: ['developers-dashboard.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class DevelopersDasboardComponent implements OnInit {

    public models$!: Observable<TradeModel[]>;
    public commodities$!: Observable<Commodity[]>;
    public trades$!: Observable<Trade[]>;
    public loadingTradeData$ = new BehaviorSubject(false);

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

        this.trades$ = this.commodityChanges$.pipe(
            mergeMap(commodityId=> this.tradeDataService.getByCommodityId(commodityId))
        )
    }

    public modelSelectionChange(modelId:number) {
        this.modelChanges$.next(modelId);
    }

    public commoditySelectionChange(commodityId:number) {
        this.commodityChanges$.next(commodityId);
    }
}