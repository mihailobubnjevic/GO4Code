import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book } from '../model/Book';
import { Observable, take } from 'rxjs';
import { AuthService } from '../auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  readonly url = 'http://localhost:5143/api/Books';

  constructor(private http: HttpClient, private authService: AuthService) { }

  createBook(book: Book){
    return this.http.post<Book>(this.url, book);
  }

  deleteById(id: string){
    return this.http.delete(this.url, {
      params: new HttpParams().set("id", id),
      headers: new HttpHeaders({"nazivheadera": "vrednost", "header2":"vrednost2"}),
    })
  }

  getAll(): Observable<Book[]>{
    return this.http.get<Book[]>(this.url);
  }
}
