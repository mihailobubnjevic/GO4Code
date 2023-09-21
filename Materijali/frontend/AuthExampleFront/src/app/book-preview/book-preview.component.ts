import { Component, Input, OnChanges } from '@angular/core';
import { Book } from '../model/Book';
import { BookService } from '../service/book.service';

@Component({
  selector: 'app-book-preview',
  templateUrl: './book-preview.component.html',
  styleUrls: ['./book-preview.component.css']
})
export class BookPreviewComponent implements OnChanges{

  @Input() updateBooks = false;

  ngOnChanges(){
    console.log("on changes called")
    this.getAllBooks();
  }
  constructor(private bookService: BookService) {
    
  }
  isLoading = false;

  books : Book[] = [];

  getAllBooks(){
    this.isLoading = true;
    setTimeout(()=>{
      this.bookService.getAll().subscribe((responseData : Book[]) =>{
        console.log(responseData);
        this.books = responseData;
        this.isLoading = false;
      });
    },1000)
    
  }
  
}
