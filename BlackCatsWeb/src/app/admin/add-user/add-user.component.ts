import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { UserRole } from '../../Enums/user-role';
import { UserService } from '../../Services/user.service';
import { ToasterService } from '../../Services/toaster-service';
import { UserRequest } from '../../Model/UserModel';

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
  UserRequest:UserRequest=new UserRequest();

  constructor(private formBuilder: FormBuilder,private service:UserService,private toasterService: ToasterService){}

  ngOnInit(): void {
    this.addUserForm = this.formBuilder.group({
      name: ['', Validators.required],  
      email: ['', [Validators.required, Validators.email]],
      contactNo: ['', Validators.required],
      userRole: [UserRole, Validators.required],
    })
  }

  openModal() {
    const myModalElement = document.getElementById(
      'my_modal_5'
    ) as HTMLDialogElement;

    myModalElement.showModal();
  }
  closeModal(){
    const myModalElement = document.getElementById(
      'my_modal_5'
    ) as HTMLDialogElement;
    myModalElement.close();
  }

  submitUser(){
    console.log(this.UserRequest)
    this.UserRequest.userRole=Number(this.UserRequest.userRole)
    this.service.addUsers(this.UserRequest).subscribe({
      next:(res)=>{
        this.toasterService.fireSuccessSwal(res.message)
        this.closeModal();
      },
      error:(err)=>{
        this.toasterService.fireErrorSwal(err.message)
        this.closeModal();
      }
    })
  }
}
