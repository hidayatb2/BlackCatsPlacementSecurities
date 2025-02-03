import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { ApiResponse } from '../Model/api-response';
import { UserResponse } from '../Model/UserModel';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.baseURL

  constructor(private  httpClient: HttpClient) { }

  getUsers(){
   return this.httpClient.get(`${this.baseUrl}Users`);
  }

  addUsers(modal:any):Observable<ApiResponse<UserResponse>>{
    return this.httpClient.post<ApiResponse<UserResponse>>(`${this.baseUrl}Users`,modal)
  }

}
