import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { UserRolePipe } from '../Pipes/enum.pipe';
import { AddUserComponent } from './add-user/add-user.component';
import { UsersComponent } from './users/users.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AdminComponent,
    DashboardComponent,
    SidebarComponent,
    UserRolePipe,
    UsersComponent,
    AddUserComponent,
  ],
  imports: [CommonModule, AdminRoutingModule, ReactiveFormsModule],
  exports: [AddUserComponent],
})
export class AdminModule {}
