import { Injectable } from '@angular/core';
import Swal from 'sweetalert2';
@Injectable({
  providedIn: 'root',
})
export class ToasterService {
  fireSuccessSwal(message: string) {
    Swal.fire({
      position: 'bottom-right',
      icon: 'success',
      title: message,
      showConfirmButton: false,
      timer: 2000,
    });
  }

  fireErrorSwal(message: string) {
    Swal.fire({
      position: 'bottom-right',
      icon: 'error',
      title: message,
      showConfirmButton: false,
      timer: 2000,
      width: 50,
      heightAuto: true,
    });
  }

  fireConfirmSwal(message: string) {
    return Swal.fire({
      title: message,
      text: "You won't be able to revert this!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes',
    });
  }
}
