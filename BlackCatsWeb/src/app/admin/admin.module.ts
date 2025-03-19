import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { UserRolePipe } from '../Pipes/enum.pipe';
import { AddUserComponent } from './add-user/add-user.component';
import { UsersComponent } from './users/users.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EdituserComponent } from './edituser/edituser.component';
import { StatusPipe } from '../Pipes/status.pipe';

@NgModule({
  declarations: [
    AdminComponent,
    DashboardComponent,
    SidebarComponent,
    UserRolePipe,
    UsersComponent,
    AddUserComponent,
    EdituserComponent,
    
  ],
  imports: [CommonModule, AdminRoutingModule, ReactiveFormsModule,FormsModule,StatusPipe],
  exports: [AddUserComponent],
})
export class AdminModule {}
