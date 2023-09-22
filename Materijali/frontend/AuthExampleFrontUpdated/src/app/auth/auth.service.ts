import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject, tap } from 'rxjs';
import { User } from './user.model';
import { Router } from '@angular/router';

export interface AuthResponse {
  token: string, 
  expiration: string
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  rootUrl: string = 'http://localhost:5143/api/Auth/';
  // user: Subject<User> = new Subject<User>();
  user: BehaviorSubject<User | null> = new BehaviorSubject<User | null>(null);

  constructor(private http: HttpClient, private router: Router) { }

  login(data: {username: string, password:string}) {
    let loginUrl = this.rootUrl + 'login';
    return this.http.post<AuthResponse>(loginUrl, data).pipe(tap((data) => {
      let user = new User(data.token, data.expiration);
      this.user.next(user);
      localStorage.setItem('user', JSON.stringify(data));
    }));
  }

  register(data: {username: string, email: string, password: string}) {
    let registerUrl = this.rootUrl + 'register';
    return this.http.post<any>(registerUrl, data);
  }

  loginAuto() {
    let user = localStorage.getItem('user');
    if(user) {
      let userJson : User  = JSON.parse(user);
      this.user.next(userJson);
    }    
  }

  logout() {
    localStorage.removeItem('user');
    this.user.next(null);
    this.router.navigate(['/auth']);
  }
}
