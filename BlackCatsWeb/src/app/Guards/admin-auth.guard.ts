import { CanActivateFn } from '@angular/router';
import { inject } from '@angular/core';
import { UserRole } from '../Enums/user-role';
import { AccountService } from '../Services/account.services';

export const adminAuthGuard: CanActivateFn = (route, state) => {
  let AccService = inject(AccountService);
  let res = AccService.isUserAuthenticated(UserRole.Admin);
  return res;
};
