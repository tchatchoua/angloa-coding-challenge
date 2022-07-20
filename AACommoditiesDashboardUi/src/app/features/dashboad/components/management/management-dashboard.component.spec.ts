import { ComponentFixture, TestBed } from "@angular/core/testing";
import { RouterTestingModule } from "@angular/router/testing";
import { CommodityDataService } from "src/app/shared/services/commodity-data.service";
import { ModelDataService } from "src/app/shared/services/model-data.service";
import { TradeDataService } from "src/app/shared/services/trade-data.service";
import { ManagementDasboardComponent } from "./management-dashboard.component";
import { of } from 'rxjs';

describe('ManagementDasboardComponent', () => {
    let component: ManagementDasboardComponent;
    let fixture: ComponentFixture<ManagementDasboardComponent>;

    const modelMockDataService = {
        getAll: ()=>  of([])
    };
    
    const commodityDataService = {};
    const tradeDataService = {}

    beforeEach(async () => {
      await TestBed.configureTestingModule({
        imports: [
          RouterTestingModule
        ],
        declarations: [
            ManagementDasboardComponent
        ],
        providers: [ 
            { provide: ModelDataService, useValue: modelMockDataService },
            { provide: CommodityDataService, useValue: commodityDataService },
            { provide: TradeDataService, useValue: tradeDataService },
    
          ]
      }).compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(ManagementDasboardComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
      });
  
    it('should create the app', () => {
      expect(component).toBeTruthy();
    });
  });