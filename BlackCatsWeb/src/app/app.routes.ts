import { Routes } from '@angular/router';
import { UserComponent } from './user/user.component';
import { adminAuthGuard } from './Guards/admin-auth.guard';

export const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./user/user.module').then((m) => m.UserModule),
  },
  {
    path: 'admin',
    loadChildren: () =>
      import('./admin/admin.module').then((m) => m.AdminModule),canActivate:[adminAuthGuard]
  },
];
