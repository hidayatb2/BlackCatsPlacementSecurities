import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { NavComponent } from './components/nav/nav.component';
import { FooterComponent } from './components/footer/footer.component';
import { LoginComponent } from './login/login.component';


@NgModule({
  declarations: [
    HomeComponent,
    AboutComponent,
    NavComponent,
    FooterComponent,
    LoginComponent
  ],
  imports: [
    CommonModule,
    UserRoutingModule
  ],
  exports: [HomeComponent, NavComponent, FooterComponent]
})
export class UserModule { }
