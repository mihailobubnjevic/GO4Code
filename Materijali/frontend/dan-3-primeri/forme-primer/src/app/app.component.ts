import { Component } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(private _snackBar: MatSnackBar) {
    
  }
  genders = ['Male', 'Female']
  onSubmit(formValue: any){
    if(formValue.gender && formValue.occupation && formValue.email && formValue.password)
    {
      this._snackBar.open("You successfully registered! Please check your email.")
    }else{
      alert("All fields are required!")
    }
    console.log(formValue);
  }
}
