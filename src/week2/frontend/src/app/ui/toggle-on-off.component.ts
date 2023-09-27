import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-toggle-on-off',
  standalone: true,
  imports: [CommonModule],
  template: `
   <button class="btn btn-circle">
      <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M6 18L18 6M6 6l12 12" /></svg>
  </button>
  `,
  styles: [
  ]
})
export class ToggleOnOffComponent {

}
