import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DevelopersDasboardComponent } from './components/developers/developers-dashboard.component';
import { ManagementDasboardComponent } from './components/management/management-dashboard.component';


const routes: Routes = [
  {
    path: 'developers',
    component: DevelopersDasboardComponent
  },
  {
    path: 'management',
    component: ManagementDasboardComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }