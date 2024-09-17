import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SidebarComponent } from "./sidebar/sidebar.component";
import { UserRolePipe } from '../Pipes/enum.pipe';


@NgModule({
  declarations: [
    AdminComponent,
    DashboardComponent,
    SidebarComponent,
    UserRolePipe,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
]
})
export class AdminModule { }
