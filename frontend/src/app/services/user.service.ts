import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoginModel } from '../models/LoginModel';
import { LoginResponse } from '../models/LoginResponse';
import { UserModel } from '../models/UserModel';
import { UserCreateModel } from '../models/UserCreateModel';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  readonly API_URL = 'http://localhost:5122';

  constructor(private http: HttpClient) {}

  login(login: LoginModel): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${this.API_URL}/User/login`, login);
  }

  getUsers(): Observable<UserModel[]> {
    return this.http.get<UserModel[]>(`${this.API_URL}/User`);
  }

  createUser(user: UserCreateModel): Observable<UserModel> {
    return this.http.post<UserModel>(`${this.API_URL}/User`, user);
  }
}
