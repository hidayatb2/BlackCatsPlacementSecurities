import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponse } from '../../Model/api-response';
import { LoginResponse } from '../../Model/login';
import { UserRole } from '../../Enums/user-role';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseURL = environment.baseURL;

  constructor(private http: HttpClient, private router:Router ) {}
  token!:ApiResponse<LoginResponse>

  verifyLogin(req: any):Observable<ApiResponse<LoginResponse>> {
    console.log(req);
    const body = {
      email : req.value.email,
      password : req.value.password
    }
    return this.http.post<ApiResponse<LoginResponse>>(`${this.baseURL}Account/login`, body);
    
     
  }

  getToken()
  {
    let token =localStorage.getItem('BCPS_Token');
    if(token!==null)
      return JSON.parse(token);
    return null
   
  }
   
  isUserAuthenticated(role:UserRole){
    if (this.getToken()){
      console.log('there is token')
      return true;
    }
     
    else{
      // this.router.navigateByUrl('/login')
      this.router.navigate(['/login'])

      return false;

    }
  }
}
