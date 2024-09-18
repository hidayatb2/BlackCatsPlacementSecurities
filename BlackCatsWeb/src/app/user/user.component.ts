import { Component, OnInit } from '@angular/core';
import { AccountService } from '../Services/account.services';
import { User } from '../Interfaces/user';
import { LoginResponse } from '../Model/login';
import { ApiResponse } from '../Model/api-response';

@Component({
  selector: 'bcss-user',
  templateUrl: './user.component.html',
  styleUrl: './user.component.scss'
})
export class UserComponent implements OnInit {
   constructor(private accountService: AccountService) {}

   ngOnInit(): void {
    this.setCurrentUser();
   }

   setCurrentUser(){
    // if (localStorage.getItem('user') != null){
    //   const user: LoginResponse = JSON.parse(atob(localStorage.getItem('user')!))
    //   this.accountService.setCurrentUser(user);
    // }
   }
}
