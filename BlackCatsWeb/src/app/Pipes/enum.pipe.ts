import { Pipe, PipeTransform } from '@angular/core';
import { UserRole } from '../Enums/user-role';

@Pipe({
  name: 'userRole'
})
export class UserRolePipe implements PipeTransform {
  transform(value: number): string {
    switch (value) {
      case UserRole.Admin:
        return 'Administrator';
      case UserRole.Manager:
        return 'Manager';
      case UserRole.Staff:
        return 'Staff';
      // Add more cases as needed
      default:
        return 'Unknown';
    }
  }
}