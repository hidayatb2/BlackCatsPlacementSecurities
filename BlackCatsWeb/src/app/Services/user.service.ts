import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.baseURL

  constructor(private  http: HttpClient) { }

  getUsers(){
   return this.http.get(`${this.baseUrl}users`);
  }

}
