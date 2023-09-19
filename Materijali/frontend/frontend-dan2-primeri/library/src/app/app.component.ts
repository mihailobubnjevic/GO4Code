import { Component } from '@angular/core';
import { Book } from './book.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  books: Book[] = [
    new Book("Harry Potter", "J.K.Rowling"),
    new Book("Lord of the Rings", "Tolkien")
  ]

  onBookAdded(book: Book) {
    this.books.push(book);
  }
}
