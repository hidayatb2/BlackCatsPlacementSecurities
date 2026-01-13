import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToasterService } from '../../Services/toaster-service';
import { AccountService } from '../../Services/account.service';
import { LoginRequest } from '../../Model/login';
@Component({
  selector: 'bcss-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent implements OnInit {
  loginForm = new FormGroup({
    email: new FormControl(),
    password: new FormControl(),
  });
  loginRequest:LoginRequest=new LoginRequest();

  constructor(
    private accountService: AccountService,
    private route: ActivatedRoute,
    private router: Router,
    private toasterService: ToasterService
  ) {}

  ngOnInit(): void {}

  verifyLogin() {
    this.accountService.verifyLogin(this.loginRequest).subscribe({
      next: (res) => {
        localStorage.setItem("BCPS-TOKEN",JSON.stringify(res.result))
        this.toasterService.fireSuccessSwal("Logged In Successfully")
        const redirectUrl =
          this.route.snapshot.queryParamMap.get('redirectUrl');
        if (redirectUrl !== null) {
          this.router.navigateByUrl(redirectUrl);
        } else {
          this.router.navigateByUrl('/admin/dashboard');
        }
      },
      error: (error) => {
        if (error) {
          this.toasterService.fireErrorSwal("Invalid Username or Password");
        }
      },
    });
  }
}
