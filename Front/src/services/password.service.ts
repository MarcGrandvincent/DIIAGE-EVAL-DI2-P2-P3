import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import {IPasswordResponse} from '../models/password.interfaces';

@Injectable({
  providedIn: 'root'
})
export class PasswordService {
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

  getPasswords(): Observable<IPasswordResponse[]> {
    return this.http.get<IPasswordResponse[]>(
      `${this.baseUrl}/passwords`, this.createHeaders()
    );
  }

  deletePassword(id: string): Observable<void> {
    return this.http.delete<void>(
      `${this.baseUrl}/passwords/${id}`, this.createHeaders()
    );
  }

  createPassword(accountName: string, password: string, applicationId: string): Observable<void> {
    return this.http.post<void>(
      `${this.baseUrl}/passwords`, {
        accountName: accountName,
        password: password,
        applicationId: applicationId
      }, this.createHeaders()
    );
  }

}
