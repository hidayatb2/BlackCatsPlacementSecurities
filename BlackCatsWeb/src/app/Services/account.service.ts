import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable, ReplaySubject } from 'rxjs';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment';
import { UserRole } from '../Enums/user-role';
import { ApiResponse } from '../Model/api-response';
import { LoginRequest, LoginResponse } from '../Model/login';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseURL = environment.baseURL;
  private currentUserSource = new ReplaySubject<LoginResponse>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient, private router: Router) {
  }

  verifyLogin(req: LoginRequest):Observable<ApiResponse<LoginResponse>> {
    // const body = {
    //   email: req.value.email,
    //   password: req.value.password,
    // };
    return this.http
      .post<ApiResponse<LoginResponse>>(`${this.baseURL}Account/login`, req);
  }

  getToken() {
    let token = localStorage.getItem('BCPS-TOKEN');
    if (token !== null) return token;
    return null;
  }

  isUserAuthenticated() {
    if (this.getToken()) {
      return true;
    } else {
      // this.router.navigateByUrl('/login')
      this.router.navigate(['/login']);

      return false;
    }
  }

  // setCurrentUser(user: LoginResponse) {
  //   this.currentUserSource.next(user);
  // }

  getCurrentUser() {
    if (localStorage.getItem('BCPS-TOKEN') == null) return null;
    const user =localStorage.getItem("BCPS-TOKEN")? JSON.parse(localStorage["BCPS-TOKEN"]) : "";
    this.currentUserSource.next(user);
    return user;
  }
  
  logout() {
    localStorage.removeItem('BCPS-TOKEN');
    this.currentUserSource.next(null!);
    this.router.navigate(['/login']).then(() => {
      window.location.reload();
    });
  }
}
