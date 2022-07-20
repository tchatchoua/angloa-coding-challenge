import { NgModule } from '@angular/core';
import { Route, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';

const appRoutes: Route[] = [
  { path: '',   redirectTo: '/home', pathMatch: 'full' },
  { path: 'home',  component: AppComponent },
  {
    path: 'dashboard',
    loadChildren: () => import('./features/dashboad/dashboard.module').then(m=>m.DashbordModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
