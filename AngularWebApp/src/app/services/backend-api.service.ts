import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Responses } from '../models/responses.model';

@Injectable({
  providedIn: 'root'
})
export class BackendApiService {

  baseUrl = 'https://localhost:7119/api/GameStoring/y/tshego';

  constructor(private http: HttpClient) { }


  // method to get the history games of the user
  getHistory(): Observable<Responses[]> {
    return this.http.get<Responses[]>(this.baseUrl);
  }

}
