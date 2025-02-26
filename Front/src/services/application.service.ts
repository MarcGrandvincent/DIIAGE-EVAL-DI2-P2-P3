import {HttpClient, HttpHeaders} from "@angular/common/http";
import { Injectable } from "@angular/core";
import {Observable} from 'rxjs';
import {IApplicationResponse} from '../models/application.interfaces';

@Injectable({
  providedIn: 'root'
})
export class ApplicationService {
  private baseUrl = "http://localhost:5066/api/v1";

  createHeaders() {
    return {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'x-api-key': '123'
      })
    }
  }

  constructor(private http: HttpClient) {
  }

  getApplications(): Observable<IApplicationResponse[]> {
    return this.http.get<IApplicationResponse[]>(
      `${this.baseUrl}/applications`, this.createHeaders()
    );
  }
}
