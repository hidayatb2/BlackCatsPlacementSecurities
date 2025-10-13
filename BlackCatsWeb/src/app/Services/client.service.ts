import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { ClientResponse, ClientRequest } from '../Model/client';
import { Observable } from 'rxjs';
import { ApiResponse } from '../Model/api-response';

@Injectable({
  providedIn: 'root',
})
export class ClientService {
  baseUrl = environment.baseURL;
  constructor(private httpClient: HttpClient) {}


  AddClient(model: FormData): Observable<ApiResponse<ClientResponse>> {
    return this.httpClient.post<ApiResponse<ClientResponse>>(
      `${this.baseUrl}Client`,
      model
    );
  }

  GetAllClient():Observable<ApiResponse<ClientResponse[]>>{
    return this.httpClient.get<ApiResponse<ClientResponse[]>>(`${this.baseUrl}Client`);
    
  }
}
