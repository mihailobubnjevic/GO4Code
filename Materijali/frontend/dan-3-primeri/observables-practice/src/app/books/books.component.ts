import { Component } from '@angular/core';
import { Book } from './book.model';
import { Observable, Subscription } from 'rxjs';
import { map, filter, catchError } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BooksService } from '../books.service';


@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent {
  books: Book[] = [];
  bookTitle: string = "Nova knjiga";
  bookAuthor: string = "Neki pisac";
  bookDescription: string = "Opis ove knjige";

  constructor(private bookService: BooksService){}
  
  ngOnInit() {
    var bookParam = new Book(this.bookTitle, this.bookDescription, this.bookAuthor);

    this.bookService.createBook(bookParam).subscribe({
      next: (data) => {
        console.log(data);
        this.books.push(data);
      }
    })
  }

  
  
  
  
  
  
  
  
  
  
  
  // cachedSubscription: Subscription = new Subscription();

  // ngOnInit() {
  //   var customObservable = new Observable<number>(observer => {
  //     let count = 0;

  //     setInterval(() => {
  //       observer.next(count);

  //       if(count === 5) {
  //         observer.error(count)
  //       }

  //       if(count == 3) {
  //         observer.complete();
  //       }

  //       count++;
  //     }, 1000);
  //   }).pipe(
  //     filter( data => {
  //       return data != 1
  //     }),
  //     map( (data : number)=> {
  //       // Izbrojao sam do broj
  //       var stringData = "Izbrojao sam do " + data;
  //       return stringData;
  //     })
  //   )

  //   this.cachedSubscription = customObservable.subscribe({
  //     next: (data) => {
  //       console.log(data);
  //     },
  //     error: (responseError) => {
  //       console.error(responseError)
  //     },
  //     complete: () => {
  //       console.log("Done")
  //     }
  //   })
  // }

  // ngOnDestroy() {
  //   this.cachedSubscription.unsubscribe();
  // }

}