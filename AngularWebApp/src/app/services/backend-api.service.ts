import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddUser } from '../models/adduser.model';
import { Responses } from '../models/responses.model';

@Injectable({
  providedIn: 'root'
})
export class BackendApiService {

  baseUrl = 'http://localhost:5279/api/GameStoring/y/T';

  constructor(private http: HttpClient) { }

  // method that is going to log the user in
  getExistingUser(): Observable<AddUser> {
    return this.http.get<AddUser>('http://localhost:5279/api/GameStoring/userExists/lebo');
  }

  // method to get the history games of the user
  getHistory(): Observable<Responses> {
    return this.http.get<Responses>(this.baseUrl);
  }

  deleteUserHistory(): Observable<Responses> {
    return this.http.get<Responses>('http://localhost:5279/api/GameStoring/deleteHistory/yes/T')
  }
  
}
