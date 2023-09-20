import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book } from './books/book.model';
import { Observable, catchError, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BooksService {

  constructor(private http: HttpClient) { }

  fetchBooks() : Observable<Book[]> {
    var url = 'http://localhost:5143/api/Books';

    return this.http.get<Book[]>(url).pipe(
      map(response => {
        return response;
      }),
    );
  }

  createBook(book: Book) : Observable<Book> {
    var url = 'http://localhost:5143/api/Books';
    var body = book;

    return this.http.post<Book>(url, body).pipe(
      map(response => {
        return new Book(response.title, response.author, response.description);
      })
    )

  }
}
