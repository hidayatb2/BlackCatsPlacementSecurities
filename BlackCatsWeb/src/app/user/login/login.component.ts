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
    username: new FormControl(''),
    password: new FormControl(''),
  });

  constructor(private accountService: AccountService) {}

  ngOnInit(): void {
    this.user();
  }

  user() {
    this.accountService.getUser().subscribe((res) => console.log(res));
  }
}
