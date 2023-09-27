import { Component, EventEmitter, Input, Output, Signal, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TodoItem } from 'src/app/services/todos-data.service';
import { ToggleOnOffComponent } from "../../../ui/toggle-on-off.component";

@Component({
  selector: 'app-todo-list',
  standalone: true,
  template: `
  <pre>{{ items | json }}</pre>
  <h2 class="text-2xl">{{message}}</h2>
   <ul>
      <li *ngFor="let item of items()" >
        <span [ngClass]="{ completed: item.completed}">{{ item.description }}</span>
      
      <app-toggle-on-off *ngIf="item.completed === false" (click)="doThis(item)"/>

      </li>
     
</ul>
  `,
  styleUrls: ['../todos.component.css'],
  imports: [CommonModule, ToggleOnOffComponent]
})
export class TodoListComponent {
  @Input({ required: true }) items: Signal<TodoItem[]> = signal([]);
  @Input() message = 'Your Todo List';
  @Output() itemMarkedComplete = new EventEmitter<TodoItem>();

  doThis(item: TodoItem) {
    this.itemMarkedComplete.emit(item); // well that happened.
  }
}
