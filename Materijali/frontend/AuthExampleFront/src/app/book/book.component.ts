import { Component } from '@angular/core';
import { Book } from '../model/Book';
import { BookService } from '../service/book.service';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent {

  updateBooks = true;
  book: Book = { title: '', description: '', author: ''}

  idToDelete = '';

  constructor(private bookService: BookService) {
    
  }
  onSubmit(){
    this.bookService.createBook(this.book).subscribe( responseData =>{
      console.log(responseData);
      this.resetForm();
    });
    this.updateBooks = !this.updateBooks;
  }

  deleteById(){
    this.bookService.deleteById(this.idToDelete).subscribe(responseData =>{
      console.log(responseData)
    },
    error =>{
      if(error.status == "404"){
        alert("That id to delete doesnt exist!")
      } else{
        alert("Oops, something went wrong!")
      }
    })
    this.updateBooks = !this.updateBooks;
  }

  resetForm(){
    this.book = { title: '', description: '', author: ''}
  }
}
