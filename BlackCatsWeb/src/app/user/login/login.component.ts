import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AccountService } from '../service/services';
@Component({
  selector: 'bcss-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent implements OnInit {
  loginForm = new FormGroup({
    email: new FormControl('admin@gmail.com'),
    password: new FormControl('admin'),
  });

  constructor(private accountService: AccountService) {}

  ngOnInit(): void {
    this.user();
  }

  verifyLogin() {
    this.accountService.verifyLogin(this.loginForm).subscribe((res:any) => {
      let data = JSON.stringify(res.result);
      console.log(res.result);
      if (res) {
        // data = JSON.stringify(res?.result)
        localStorage['user' ] = data
      }
    });
  }


}
