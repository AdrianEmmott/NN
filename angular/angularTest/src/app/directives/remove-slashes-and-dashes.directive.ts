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
    //console.log(this.el);

    var textValue = this.el.nativeElement.innerHTML;
    //debugger;
    if(textValue !== undefined) {
      const forwardSlashRegex = /(\/)/g;
      const hyphensRegex = /-/g;
  
      textValue  = textValue.replace(forwardSlashRegex, " > ");
      textValue = textValue.replace(hyphensRegex, " ");
  
      //console.log(textValue);
  
      this.el.nativeElement.innerHTML = textValue;
    } 
  }

  ngDoCheck() {
//debugger;
    
  }
}
