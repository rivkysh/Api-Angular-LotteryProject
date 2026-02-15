import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../app/Models/User';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private baseUrl = "http://localhost:5009/api/User";
  constructor(private http: HttpClient,private router: Router) { }
  

  register(userData: User): Observable<any> {
    return this.http.post<User>(`${this.baseUrl}/Register`, userData);
  }
  login(credentials: { username: string; password: string }): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/Login`, credentials);
  }
  isUser(): boolean {
    const role = localStorage.getItem('role');
    return role === 'user';
  }
  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }
  getRole(): string | null {
  return localStorage.getItem('role'); // מחזיר 'Admin', 'User' או null
}
logout(): void {
  localStorage.removeItem('token');
  localStorage.removeItem('username');
  localStorage.removeItem('role');
  this.router.navigate(['/login']);

}
}
