import { Pipe, PipeTransform } from '@angular/core';
import { UserRole } from '../Enums/user-role';

@Pipe({
  name: 'userRole'
})
export class UserRolePipe implements PipeTransform {
  transform(value: number): string {
    switch (value) {
      case UserRole.Admin:
        return 'Admin';
      case UserRole.Manager:
        return 'Manager';
      case UserRole.Staff:
        return 'Staff';
      default:
        return 'Unknown';
    }
  }
}