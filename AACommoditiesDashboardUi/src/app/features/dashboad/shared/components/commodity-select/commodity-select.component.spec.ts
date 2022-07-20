import { ComponentFixture, TestBed } from "@angular/core/testing";
import { RouterTestingModule } from "@angular/router/testing";
import { CommoditySelectComponent } from "./commodity-select.component";

describe('CommoditySelectComponent', () => {
    let component: CommoditySelectComponent;
    let fixture: ComponentFixture<CommoditySelectComponent>;

    beforeEach(async () => {
      await TestBed.configureTestingModule({
        imports: [
          RouterTestingModule
        ],
        declarations: [
            CommoditySelectComponent
        ],
      }).compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(CommoditySelectComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
      });
  
    it('should create the app', () => {
      expect(component).toBeTruthy();
    });
  });