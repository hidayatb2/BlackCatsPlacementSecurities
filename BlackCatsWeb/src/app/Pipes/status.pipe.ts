import { Pipe, PipeTransform } from '@angular/core';
import { UserStatus } from '../Enums/user-status';

@Pipe({
  name: 'status',
  standalone: true
})
export class StatusPipe implements PipeTransform {

  transform(value: number, ...args: unknown[]): string {
    switch(value){
      case UserStatus.Active:
        return 'Active';
      case UserStatus.Inactive:
        return 'InActive'
      default:
        return 'Unknown'
    }

  }

}
