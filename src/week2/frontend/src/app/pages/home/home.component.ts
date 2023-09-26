import { Component, signal } from "@angular/core";
import { CommonModule } from "@angular/common";
import { HeadingComponent } from "../../components/heading/heading.component";

@Component({
  selector: "app-home",
  standalone: true,
  template: `
    <app-heading />
    <p *ngIf="showMessage() === true">This is our dashboard for the app.</p>
    <button (click)="toggleMessage()" type="button" class="btn btn-secondary">
      Toggle Message
    </button>
    <ul>
      <li *ngFor="let shoppingItem of shoppingList()">{{ shoppingItem }}</li>
    </ul>
  `,
  styles: [],
  imports: [CommonModule, HeadingComponent],
})
export class HomeComponent {
  showMessage = signal(true);
  shoppingList = signal(["Bread", "Beer", "Shampoo"]);

  toggleMessage() {
    this.showMessage.set(!this.showMessage());
  }
}
