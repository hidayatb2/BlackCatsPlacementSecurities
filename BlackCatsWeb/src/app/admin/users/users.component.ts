import { Component, OnInit } from '@angular/core';
import { UserService } from '../../Services/user.service';
import { ToasterService } from '../../Services/toaster-service';
import { UpdateUserRequest, UserResponse } from '../../Model/add-users';

@Component({
  selector: 'bcss-users',
  templateUrl: './users.component.html',
  styleUrl: './users.component.scss',
})
export class UsersComponent implements OnInit {
  users!: UserResponse[];
  isClicked: boolean = false;
  updateRequest:UpdateUserRequest=new UpdateUserRequest()

  constructor(private userService: UserService,private alertService:ToasterService) {}

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers() {
    this.userService.getUsers().subscribe({
      next:(res)=>{
        this.users = res.result;
      }
    })
  }
  deleteUser(id:string){
    this.alertService.fireConfirmSwal("Are Your Sure You Want to Delet The User").then((res)=>{
      if(res.isConfirmed){
        this.userService.deleteUser(id).subscribe({
          next:(result)=>{
            this.alertService.fireSuccessSwal("User Deleted Successfully")
            this.getUsers();
          },
          error:(err)=>{
            this.alertService.fireErrorSwal("Error Deleting User")
          }
        })
      }
    });
    
  }

  showDetails(userId:string) {
    this.userService.getUserById(userId).subscribe({
      next: (response) => {
        console.log(userId);
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
  openModal(userId:string) {
    const myModalElement = document.getElementById(
      'my_modal_6'
    ) as HTMLDialogElement;
    myModalElement.showModal();
    this.showDetails(userId);
  }

  closeModal() {
    const modal = document.getElementById('my_modal_6') as HTMLDialogElement;
    if (modal && modal.open) {
      modal.close();
    }
  }

  editUser() {
    this.updateRequest.userStatus=Number(this.updateRequest.userStatus)
    this.userService.editUser(this.updateRequest).subscribe({
      next: (res) => {
        this.alertService.fireSuccessSwal(res.message);
        this.getUsers()
      },
      error: (err) => {
        this.alertService.fireErrorSwal(err.error.message);
      },
    });
  }
}
