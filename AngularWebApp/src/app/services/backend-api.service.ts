import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddUser } from '../models/adduser.model';
import { Responses } from '../models/responses.model';

@Injectable({
  providedIn: 'root'
})
export class BackendApiService {

  baseUrl = 'http://localhost:5279/api/GameStoring/';

  constructor(private http: HttpClient) { }

  // method that is going to log the user in
  getExistingUser(username: string): Observable<AddUser> {
    return this.http.get<AddUser>(this.baseUrl + `userExists/${username}`);
  }

  // method to register a new user
  registerNewUser(username: string): Observable<AddUser> {
    return this.http.get<AddUser>(this.baseUrl + `${username}`);
  }

  // method to get the history games of the user
  getHistory(username: string): Observable<Responses> {
    return this.http.get<Responses>(this.baseUrl + `y/${username}`);
  }

  //method to delete history of user
  deleteUserHistory(username: string): Observable<Responses> {;
    return this.http.delete<Responses>(this.baseUrl + `deleteHistory/yes/${username}`);
  }

  // method to delete the user completely along with game history
  deleteUser(username: string): Observable<Responses> {
    return this.http.delete<Responses>(this.baseUrl + `delete/user/${'delete'}/${username}`);
  }

  // method to start game
  StartGame(): Observable<Responses> {
    return this.http.get<Responses>(this.baseUrl + `start`);
  }

  // method for playing game
  PlayGuessingGame(username: string, id: number, guess: number): Observable<Responses> {
    return this.http.get<Responses>(this.baseUrl + `${username}/${id}/${guess}`)
  }
  
}
