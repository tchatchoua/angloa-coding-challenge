import { NgModule } from '@angular/core';
import {MatSelectModule,} from '@angular/material/select';
import {MatTableModule} from '@angular/material/table';

const MATERIAL_MODULES = [
  MatSelectModule,
  MatTableModule
];

@NgModule({
  imports: [
    MATERIAL_MODULES
  ],
  exports: [
    MATERIAL_MODULES
  ]
})
export class SharedMaterialModule { }