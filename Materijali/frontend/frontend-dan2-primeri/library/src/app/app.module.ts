import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BookComponent } from './book/book.component';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { TurnsElementGreenDirective } from './turns-element-green.directive';
import { CreateBookComponent } from './create-book/create-book.component';


@NgModule({
  declarations: [
    AppComponent,
    BookComponent,
    TurnsElementGreenDirective,
    CreateBookComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    MatButtonModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
