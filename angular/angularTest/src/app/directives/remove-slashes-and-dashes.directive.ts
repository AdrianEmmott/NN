import {Directive, ElementRef, OnInit, DoCheck } from '@angular/core';
import { Router } from '@angular/router';

@Directive({
  selector: '[removeSlashesAndDashes]'
})
export class RemoveSlashesAndDashesDirective implements OnInit {

  constructor(private el: ElementRef) { 
  }

  ngOnInit() {
    
  }

  ngAfterViewInit(){
    var textValue = this.el.nativeElement.innerHTML;

    if(textValue !== undefined) {
      const forwardSlashRegex = /(\/)/g;
      const hyphensRegex = /-/g;
  
      textValue  = textValue.replace(forwardSlashRegex, " > ");
      textValue = textValue.replace(hyphensRegex, " ");

      this.el.nativeElement.innerHTML = textValue;
    } 
  }

  ngDoCheck() {
    
  }
}
