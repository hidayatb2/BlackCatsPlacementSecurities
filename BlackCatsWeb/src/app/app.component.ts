import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { UserModule } from './user/user.module';
import { HomeComponent } from './user/home/home.component';
import { AdminModule } from './admin/admin.module';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, UserModule,AdminModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  title = 'BlackCatsWeb';

  ngOnInit(): void{
 
  }
}
