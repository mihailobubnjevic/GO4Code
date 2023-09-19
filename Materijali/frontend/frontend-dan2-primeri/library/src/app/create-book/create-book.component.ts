import { Component, EventEmitter, Output } from '@angular/core';
import { Book } from '../book.model';

@Component({
  selector: 'app-create-book',
  templateUrl: './create-book.component.html',
  styleUrls: ['./create-book.component.css']
})
export class CreateBookComponent {
  @Output() addBookEventEmitter: EventEmitter<Book> = new EventEmitter<Book>();
  newTitle: string = '';
  newAuthor: string = '';

  onAddBook() {
    console.log('U eventu sam');
    let book = new Book(this.newTitle, this.newAuthor);
    this.addBookEventEmitter?.emit(book);
  }
}
