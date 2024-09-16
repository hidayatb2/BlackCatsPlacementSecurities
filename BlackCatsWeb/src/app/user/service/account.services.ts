import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { map, Observable, ReplaySubject } from 'rxjs';
import { ApiResponse } from '../../Model/api-response';
import { LoginResponse } from '../../Model/login';
import { UserRole } from '../../Enums/user-role';
import { Router } from '@angular/router';
import { User } from '../../Interfaces/user';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseURL = environment.baseURL;
  private currentUserSource = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient, private router: Router) {}
  token!: ApiResponse<LoginResponse>;

  verifyLogin(req: any) {
    const body = {
      email: req.value.email,
      password: req.value.password,
    };
    return this.http.post<User>(`${this.baseURL}Account/login`, body).pipe(
      map((response: User) => {
        const user = response;
        if (user) {
          localStorage.setItem('user', btoa(JSON.stringify(user)));
          this.currentUserSource.next(user);
        }
      })
    );
  }

  getToken() {
    let token = localStorage.getItem('user');
    if (token !== null) return token;
    return null;
  }

  isUserAuthenticated(role: UserRole) {
    if (this.getToken()) {
      return true;
    } else {
      // this.router.navigateByUrl('/login')
      this.router.navigate(['/login']);

      return false;
    }
  }

  setCurrentUser(user: User) {
    this.currentUserSource.next(user);
  }

  getCurrentUser() {
    if (localStorage.getItem('user') == null) return null;
    return JSON.parse(atob(localStorage.getItem('user')!));
  }
}
