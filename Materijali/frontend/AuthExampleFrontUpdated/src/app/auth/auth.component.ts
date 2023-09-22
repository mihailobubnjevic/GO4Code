import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthResponse, AuthService } from './auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent {
  isLoginMode: boolean = false;

  constructor(private _snackBar: MatSnackBar, private authService: AuthService, private router: Router){}

  onSubmit(form: NgForm) {
    if(form.invalid) {
      return;
    }

    let user = form.value.username;
    let password = form.value.password;
    let email = form.value.email;

    if(this.isLoginMode) {
      // login ovde
      this.authService.login({username: user, password: password}).subscribe({
        next: (data: AuthResponse) => {
          this.router.navigate(['/books'])
        }
      })
    } else {
      // register ovde
      this.authService.register({username: user, email: email, password: password}).subscribe({
        next: () => {
          this.openSnackBar('Registered successfully');
        },
        error: () => {
          this.openSnackBar('Couldnt register');
        }
      })
    }

    form.reset();
  }

  onSwitchMode() {
    this.isLoginMode = !this.isLoginMode;
  }

  openSnackBar(message: string) {
    let action: string = 'Dismiss';
    this._snackBar.open(message, action);
  }
}
