import { CanActivateFn } from '@angular/router';
import { AccountService } from '../user/service/services';
import { inject } from '@angular/core';
import { UserRole } from '../Enums/user-role';

export const adminAuthGuard: CanActivateFn = (route, state) => {
  let AccService=inject(AccountService);
  return AccService.isUserAuthenticated(UserRole.Admin);
};
