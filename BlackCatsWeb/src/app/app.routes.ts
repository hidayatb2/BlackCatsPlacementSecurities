import { Routes } from '@angular/router';
import { UserComponent } from './user/user.component';

export const routes: Routes = [{
    path: '',
    loadChildren : () =>  import('./user/user.module').then(m => m.UserModule)
    

}];
