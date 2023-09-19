import { Directive, ElementRef } from '@angular/core';

@Directive({
  selector: '[appTurnsElementGreen]'
})
export class TurnsElementGreenDirective {

  constructor(private elementRef: ElementRef) {
      elementRef.nativeElement.color = 'green';
   }
}
