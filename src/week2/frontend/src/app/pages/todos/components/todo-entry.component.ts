import { Component } from "@angular/core";
import { CommonModule } from "@angular/common";

@Component({
  selector: "app-todo-entry",
  standalone: true,
  imports: [CommonModule],
  template: `
    <label for="item">Item</label>
    <input type="text" id="item" />
    <button>Add Item</button>
  `,
  styles: [],
})
export class TodoEntryComponent {}
