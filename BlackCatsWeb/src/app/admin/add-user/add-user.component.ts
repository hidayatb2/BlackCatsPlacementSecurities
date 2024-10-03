import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { UserRole } from '../../Enums/user-role';

@Component({
  selector: 'bcss-add-user',
  templateUrl: './add-user.component.html',
  styleUrl: './add-user.component.scss',
})
export class AddUserComponent implements OnInit {
  addUserForm: FormGroup = new FormGroup({
    name: new FormControl(''),
    email: new FormControl(''),
    contactNo: new FormControl(''),
    userRole: new FormControl(UserRole),
  });

  constructor(private formBuilder: FormBuilder){}

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
}
