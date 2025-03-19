import { Component, Input, NgZone, OnInit } from '@angular/core';
import { UpdateUserRequest } from '../../Model/add-users';
import { UserService } from '../../Services/user.service';
import { ToasterService } from '../../Services/toaster-service';

@Component({
  selector: 'bcss-edituser',
  templateUrl: './edituser.component.html',
  styleUrl: './edituser.component.scss',
})
export class EdituserComponent implements OnInit {
  @Input() userId: string = '';
  updateRequest: UpdateUserRequest = new UpdateUserRequest();

  constructor(
    private userService: UserService,
    private toasterService: ToasterService,
  ) {}
  ngOnInit(): void {
  }

  showDetails() {
    this.userService.getUserById(this.userId).subscribe({
      next: (response) => {
        console.log(this.userId);
        console.log(response);
          this.updateRequest.name = response.result.name;
          this.updateRequest.id = response.result.id;
          this.updateRequest.contactNo = response.result.contactNo;
          this.updateRequest.userRole = response.result.userRole;
          this.updateRequest.userStatus = response.result.userStatus;
        console.log(this.updateRequest)
      },
    });
  }
  openModal() {
    const myModalElement = document.getElementById(
      'my_modal_6'
    ) as HTMLDialogElement;
    myModalElement.showModal();
    this.showDetails();
  }

  closeModal() {
    const modal = document.getElementById('my_modal_6') as HTMLDialogElement;
    if (modal && modal.open) {
      modal.close();
    }
  }

  editUser() {
    this.userService.editUser(this.updateRequest).subscribe({
      next: (res) => {
        this.toasterService.fireSuccessSwal(res.message);
      },
      error: (err) => {
        this.toasterService.fireErrorSwal(err.error.message);
      },
    });
  }
}
