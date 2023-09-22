import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit{
  isAuthenticated: boolean = false;
  userSub: Subscription = new Subscription()

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.userSub = this.authService.user.subscribe({
      next: (data) => {
        this.isAuthenticated = data ? true : false;
      }
    })
  }

  logout() : void {
    this.authService.logout();
  }

}
