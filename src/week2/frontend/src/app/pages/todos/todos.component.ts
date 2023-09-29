import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TodoEntryComponent } from "./components/todo-entry.component";
import { TodoListComponent } from "./components/todo-list.component";
import { TodoItem, TodosDataService } from 'src/app/services/todos-data.service';
import { Store } from '@ngrx/store';
import { todosFeature } from './state';
import { TodosEvents } from './state/todos.actions';

@Component({
  standalone: true,
  template: `
  <div *ngIf="error()" class="alert alert-error">
    <svg xmlns="http://www.w3.org/2000/svg" class="stroke-current shrink-0 h-6 w-6" fill="none" viewBox="0 0 24 24"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M10 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2m7-2a9 9 0 11-18 0 9 9 0 0118 0z" /></svg>
    <span>Sorry - unable to change that status</span>
  </div>
   <section>
    <app-todo-entry (itemAdded)="timeToAddAnItem($event)" />
   </section>
   <section>
    <app-todo-list [items]="todoItems" message="Here is all the stuff you have to do!" (itemMarkedComplete)="timeToMarkItemComplete($event)" />
   </section>
  `,
  styleUrls: ["./todos.component.css"],
  imports: [CommonModule, TodoEntryComponent, TodoListComponent]
})
export class TodosComponent {


  todoItems = this.store.selectSignal(todosFeature.selectTodoList)
  sayThis = 'Demo Header';

  error = this.store.selectSignal(todosFeature.selectHasError);

  constructor(private readonly store: Store) {
    store.dispatch(TodosEvents.entered());

  }

  timeToAddAnItem(description: string) {
    this.store.dispatch(TodosEvents.todoItemAdded({ description }));
  }

  timeToMarkItemComplete(item: TodoItem) {
    this.store.dispatch(TodosEvents.todoItemCompleted( { payload: item } ));
  }
}
