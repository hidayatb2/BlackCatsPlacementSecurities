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
import { StatusPipe } from '../Pipes/status.pipe';
import { AddClientComponent } from './client/add-client/add-client.component';
import { GetClientComponent } from './client/get-client/get-client.component';

@NgModule({
  declarations: [
    AdminComponent,
    DashboardComponent,
    SidebarComponent,
    UserRolePipe,
    UsersComponent,
    AddUserComponent,
    AddClientComponent,
    GetClientComponent
    
  ],
  imports: [CommonModule, AdminRoutingModule, ReactiveFormsModule,FormsModule,StatusPipe],
  exports: [AddUserComponent],
})
export class AdminModule {}
