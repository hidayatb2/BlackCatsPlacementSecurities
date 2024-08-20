import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseURL = environment.baseURL;

  constructor(private http: HttpClient) {}

  verifyLogin(req: any) {
    console.log(req);
    const body = {
      email : req.value.email,
      password : req.value.password
    }
    return this.http.post(`${this.baseURL}Account/login`, body);
  }
}
