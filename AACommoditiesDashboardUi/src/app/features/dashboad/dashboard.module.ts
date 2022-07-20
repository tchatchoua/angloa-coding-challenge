import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { SharedMaterialModule } from "src/app/shared/shared-material.module";
import { SharedModule } from "src/app/shared/shared.module";
import { DevelopersDasboardComponent } from "./components/developers/developers-dashboard.component";
import { ManagementDasboardComponent } from "./components/management/management-dashboard.component";
import { DashboardRoutingModule } from "./dashboard-routing.module";

// COMPONENTS
const COMPONENTS = [
    DevelopersDasboardComponent, 
    ManagementDasboardComponent
];

@NgModule({
    imports: [
      CommonModule,
      DashboardRoutingModule,
      SharedModule
    ],
    declarations: [
        COMPONENTS
    ],
    exports:[]

  })
  export class DashbordModule { }