import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
    selector: '[appTwoDigitDecimaNumber]'
  })
  export class TwoDigitDecimaNumberDirective {
    // Allow decimal numbers without negative values
    private regex: RegExp = new RegExp(/^\d{0,12}\.?\d{0,2}$/g); // Excluding numbers in billions
    // Allow key codes for special events. Reflect :
    // Backspace, tab, end, home
    private specialKeys: Array<string> = ['Backspace', 'Tab', 'End', 'Home', 'ArrowLeft', 'ArrowRight', 'Del', 'Delete'];
  
    constructor(private el: ElementRef) {}
  
    @HostListener('keydown', ['$event'])
    onKeyDown(event: KeyboardEvent) {
      // Allow Backspace, tab, end, and home keys
      if (this.specialKeys.indexOf(event.key) !== -1) {
        return;
      }
  
      // Prevent typing '-' character
      if (event.key === '-') {
        event.preventDefault();
        return;
      }
  
      let current: string = this.el.nativeElement.value;
      const selectionStart = this.el.nativeElement.selectionStart;
      const selectionEnd = this.el.nativeElement.selectionEnd;
  
      let next: string;
      if (selectionStart !== selectionEnd) {
        // Replace selected text with the new input
        next = current.slice(0, selectionStart) + event.key + current.slice(selectionEnd);
      } else {
        // Insert the new input at the caret position
        next = [current.slice(0, selectionStart), event.key == 'Decimal' ? '.' : event.key, current.slice(selectionStart)].join('');
      }
  
      if (next && !String(next).match(this.regex)) {
        event.preventDefault();
      }
  
      if (next.length > 15) { // 12 digits + 1 decimal point + 2 decimals
        this.el.nativeElement.value = ''; // Clear the input
        this.el.nativeElement.dispatchEvent(new Event('input')); // Trigger input event to update ngModel if present
      }
    }
  }