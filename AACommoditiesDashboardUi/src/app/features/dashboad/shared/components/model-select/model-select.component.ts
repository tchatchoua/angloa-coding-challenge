import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnChanges, Output, SimpleChanges } from "@angular/core";
import { TradeModel } from "src/app/models";

@Component({
    selector: 'app-model-select',
    templateUrl: 'model-select.component.html',
    styleUrls: ['model-select.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ModelSelectComponent implements OnChanges{
    

    @Input()
    models!: TradeModel[];

    @Output() selectionChanged:EventEmitter<number> = new EventEmitter();

    public selectedModelId: number=0;

    ngOnChanges(): void {
        if(this.models.length>0) {
            this.selectedModelId = this.models[0].id;
            this.selectionChanged.emit(this.selectedModelId);
        }
    }

    public modelSelectionChange(modelId: number) {
        this.selectionChanged.emit(modelId);
    }

}