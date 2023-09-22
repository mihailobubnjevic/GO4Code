import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BookPreviewComponent } from './book-preview/book-preview.component';
import { BookComponent } from './book/book.component';

import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthComponent } from './auth/auth.component';

import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatButtonModule} from '@angular/material/button';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatDividerModule } from '@angular/material/divider'
import {MatToolbarModule} from '@angular/material/toolbar'
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { HeaderComponent } from './header/header.component';
import { AuthInterceptorService } from './auth/auth-interceptor.service';
import { AuthGuardService } from './auth/auth-guard.service';

const appRoutes: Routes = [
  { path: '', redirectTo: 'books', pathMatch: 'full'},
  { path: 'books', component: BookPreviewComponent, pathMatch: 'full' },
  { path: 'edit', component: BookComponent, pathMatch: 'full', canActivate: [AuthGuardService]},
  { path: 'auth', component: AuthComponent, pathMatch: 'full'}
]

@NgModule({
  declarations: [
    AppComponent,
    BookPreviewComponent,
    BookComponent,
    AuthComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule,
    MatProgressSpinnerModule,
    MatDividerModule,
    MatToolbarModule,
    BrowserAnimationsModule,
    MatSnackBarModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptorService,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
