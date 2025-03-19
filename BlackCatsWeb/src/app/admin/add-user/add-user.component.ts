import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { UserRole } from '../../Enums/user-role';
import { UserRequest } from '../../Model/add-users';
import { UserService } from '../../Services/user.service';
import { ToasterService } from '../../Services/toaster-service';

@Component({
  selector: 'bcss-add-user',
  templateUrl:'./add-user.component.html',
  styleUrl: './add-user.component.scss',
})
export class AddUserComponent implements OnInit {
  addUserForm: FormGroup = new FormGroup({
    name: new FormControl(''),
    email: new FormControl(''),
    contactNo: new FormControl(''),
    userRole: new FormControl(UserRole),
  });
  addUserRequest:UserRequest=new UserRequest();

  constructor(private formBuilder: FormBuilder,private service:UserService,private alertService:ToasterService){}

  ngOnInit(): void {
   
  }

  addUser(){
    this.addUserRequest.userRole=Number(this.addUserRequest.userRole);
    this.service.addUser(this.addUserRequest).subscribe({
      next: (response) => {
        this.alertService.fireSuccessSwal("User Added Successfully");
        

      },
      error: (err) => {
        this.alertService.fireErrorSwal(`${err.message}`);
      }
    })
  }

  openModal() {
    const myModalElement = document.getElementById(
      'my_modal_5'
    ) as HTMLDialogElement;

    myModalElement.showModal();
  }

  closeModal() {
    const modal = document.getElementById('my_modal_5') as HTMLDialogElement;
    if (modal && modal.open) {
      modal.close();
    }
  }
}
