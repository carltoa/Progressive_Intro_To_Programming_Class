import { Injectable, signal } from "@angular/core";

@Injectable({
  providedIn: "root",
})
export class TodosDataService {
  private items: TodoItem[] = [
    { id: "1", description: "Beer", completed: false },
    { id: "2", description: "Shampoo", completed: true },
  ];

  getItems() {
    return signal(this.items).asReadonly();
  }
}

export interface TodoItem {
  id: string;
  description: string;
  completed: boolean;
}
