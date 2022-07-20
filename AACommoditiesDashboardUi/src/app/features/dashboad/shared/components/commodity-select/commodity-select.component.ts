import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges } from "@angular/core";
import { Commodity } from "src/app/models";

@Component({
    selector:'app-commodity-select',
    templateUrl:'commodity-select.component.html',
    styleUrls: ['commodity-select.component.scss']
})
export class CommoditySelectComponent implements OnChanges {
    

    @Input() commodities!: Commodity[];
    @Output() selectionChanged:EventEmitter<number> = new EventEmitter();
    
    public selecetCommodityId!:number;

    ngOnChanges(): void {
        if(this.commodities.length>0) {
            this.selecetCommodityId = this.commodities[0].id;
            this.selectionChanged.emit(this.selecetCommodityId)
        }
    }

    public commoditySelectionChange(commodityId: number) {
        this.selectionChanged.emit(commodityId);
    }
}