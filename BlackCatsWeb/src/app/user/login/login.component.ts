import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AccountService } from '../service/account.services';
import { ActivatedRoute, Router } from '@angular/router';
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

  constructor(
    private accountService: AccountService,
    private route: ActivatedRoute,
    private router: Router,
    //private toastrService: ToastrService
  ) {}

  ngOnInit(): void {}

  verifyLogin() {
    this.accountService.verifyLogin(this.loginForm).subscribe({
      next: () => {
        //this.toastrService.success("You're logged in successfully");
        const redirectUrl =
          this.route.snapshot.queryParamMap.get('redirectUrl');
        if (redirectUrl !== null) {
          this.router.navigateByUrl(redirectUrl);
        } else {
          this.router.navigateByUrl('/admin/home');
        }
      },
      error: (error) => {
        if (error.status == 401) {
          //this.toastrService.warning('Invalid username or password');
        } else {
          //this.toastrService.error('There was some error on login');
        }
      },
    });
  }
}
