import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { ModelDataService } from 'src/app/shared/services/model-data.service';
import { DevelopersDasboardComponent } from './developers-dashboard.component';
import { of } from 'rxjs';
import { TradeModel } from 'src/app/models';
import { CommodityDataService } from 'src/app/shared/services/commodity-data.service';
import { TradeDataService } from 'src/app/shared/services/trade-data.service';

describe('DevelopersDasboardComponent', () => {
  let component: DevelopersDasboardComponent;
  let fixture: ComponentFixture<DevelopersDasboardComponent>;

  var fakeModels:TradeModel[] = [
    {id:1, name:'model1'},
    {id:2, name: 'model2'},
    {id:3, name: 'model3'}
 ];

  const modelMockDataService = {
    getAll: ()=>  of(fakeModels)
  };

  const commodityDataService = {};
  const tradeDataService = {}

  beforeEach(async() => {
    TestBed.configureTestingModule({
      declarations: [ DevelopersDasboardComponent ],
      providers: [ 
        { provide: ModelDataService, useValue: modelMockDataService },
        { provide: CommodityDataService, useValue: commodityDataService },
        { provide: TradeDataService, useValue: tradeDataService },

      ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DevelopersDasboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    // arrange && act && assert
    expect(component).toBeTruthy();
  });

  it('should return load models on initialisation', (done) => {
    // arrange
    var expectedModels:TradeModel[] = [
        {id:1, name:'model1'},
        {id:2, name: 'model2'},
        {id:3, name: 'model3'}
    ];

    spyOn(modelMockDataService, 'getAll').and.returnValue(of(expectedModels));

    // act
    component.ngOnInit();

    // assert
    component.models$.subscribe(data=> {
        expect(data).toEqual(expectedModels)
        done();
    })
  });
});
