import { CommonModule } from "@angular/common";
import { Component, signal } from "@angular/core";
import { HeadingComponent } from "../../components/heading/heading.component";

@Component({
  standalone: true,
  template: `
   <app-heading />
    <p *ngIf="showMessage() === true">This is our dashboard for the app.</p>
    <button (click)="toggleMessage()" type="button" class="btn btn-secondary">Toggle Message</button>
    <ul>
      <li *ngFor="let shoppingItem of shoppingList()">{{shoppingItem}}</li>
    </ul>
  `,
  styles: [],
  imports: [HeadingComponent, CommonModule]
})
export class HomeComponent {


  showMessage = signal(true)

  shoppingList = signal(['Bread', 'Beer', 'Shampoo']);

  toggleMessage() {
    this.showMessage.set(!this.showMessage());
  }
}
