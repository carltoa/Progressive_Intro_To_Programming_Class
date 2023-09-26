import { Component } from "@angular/core";
import { CommonModule } from "@angular/common";
import { TodoListComponent } from "./components/todo-list.component";
import { TodoEntryComponent } from "./components/todo-entry.component";
import { TodosDataService } from "src/app/services/todos-data.services";

@Component({
  selector: "app-todos",
  standalone: true,
  template: `
    <section>
      <app-todo-entry></app-todo-entry>
    </section>
    <section>
      <app-todo-list [items]="todoItems()" ]></app-todo-list>
    </section>
  `,
  styleUrls: ["./todos.component.css"],
  imports: [CommonModule, TodoListComponent, TodoEntryComponent],
})
export class TodosComponent {
  todoItems = this.service.getItems();
  constructor(private readonly service: TodosDataService) {}
}
