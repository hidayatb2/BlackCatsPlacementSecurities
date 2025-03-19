import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { UpdateUserRequest, UserRequest, UserResponse } from '../Model/add-users';
import { ApiResponse } from '../Model/api-response';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.baseURL

  constructor(private  http: HttpClient) { }

getUsers():Observable<ApiResponse<UserResponse[]>>{
   return this.http.get<ApiResponse<UserResponse[]>>(`${this.baseUrl}Users`);
}
deleteUser(id:string){
  return this.http.delete(`${this.baseUrl}Users/${id}`);
}
addUser(model:UserRequest):Observable<ApiResponse<UserResponse>>{
  return this.http.post<ApiResponse<UserResponse>>(`${this.baseUrl}Users`,model);
}
editUser(model:UpdateUserRequest):Observable<ApiResponse<UserResponse>>{
  return this.http.put<ApiResponse<UserResponse>>(`${this.baseUrl}Users`,model)
}
getUserById(id:string):Observable<ApiResponse<UserResponse>>{
  return this.http.get<ApiResponse<UserResponse>>(`${this.baseUrl}Users/${id}`);
}
}
