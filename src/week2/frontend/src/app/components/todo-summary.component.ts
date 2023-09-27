import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TodosDataService } from '../services/todos-data.service';

@Component({
  selector: 'app-todo-summary',
  standalone: true,
  imports: [CommonModule],
  template: `
   <button class="btn">
  Todo Items
  <div class="badge">{{summary().total}}</div>
</button>
<button class="btn">
  Todo Items Completed
  <div class="badge badge-secondary">{{summary().complete}}</div>
</button>
<button class="btn">
  Todo Items Incomplete
  <div class="badge badge-secondary">{{summary().incomplete}}</div>
</button>
  `,
  styles: [
  ]
})
export class TodoSummaryComponent {


  constructor(private readonly service: TodosDataService) {

  }
  summary = this.service.getSummary();
}


export interface TodoSummary {
  total: number;
  incomplete: number;
  complete: number;
}