import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseURL = environment.baseURL;

  constructor(private http: HttpClient) {}

  getUser() {
    const body = {
      Email: 'admin@gmail.com',
      Password: 'admin',
    };
    return this.http.post(`${this.baseURL}Account/login`, body);
  }
}
