import { NgModule } from '@angular/core';
import { SharedMaterialModule } from './shared-material.module';
import { ModelSelectComponent } from '../features/dashboad/shared/components/model-select/model-select.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { CommoditySelectComponent } from '../features/dashboad/shared/components/commodity-select/commodity-select.component';
import { TradeTableComponent } from '../features/dashboad/shared/components/trade-table/trade-table.component';

// Components
const COMPONENTS = [
    ModelSelectComponent,
    CommoditySelectComponent,
    TradeTableComponent
]

// Modules
const MODULES = [
    SharedMaterialModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    HttpClientModule,
]

@NgModule({
declarations: [
    COMPONENTS
  ],
  imports: [
    MODULES
  ],
  exports: [
    COMPONENTS,
  ]
})
export class SharedModule { }