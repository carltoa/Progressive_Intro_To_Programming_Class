import { Injectable, computed, signal } from "@angular/core";
import { TodoSummary } from "../components/todo-summary.component";

@Injectable({
    providedIn: 'root'
})
export class TodosDataService {


    private items = signal<TodoItem[]>([
        { id: '1', description: 'Beer', completed: false },
        { id: '2', description: 'Shampoo', completed: true }
    ]);

    getItems() {
        return signal(this.items);
    }
    addItem(description: string) {
        const itemToAdd: TodoItem = {
            id: crypto.randomUUID(),
            description,
            completed: false
        };
        this.items.mutate((items) => items.push(itemToAdd));
    }

    markItemComplete(item: TodoItem) {

        this.items.mutate(items => {
            const savedItem = items.find(i => i.id === item.id);
            if (savedItem) {
                savedItem.completed = true
            }
        });

    }

    getSummary() {
        return computed(() => ({
            total: this.items().length,
            complete: this.items().filter(t => t.completed === true).length,
            incomplete: this.items().filter(t => t.completed === false).length
        }) as TodoSummary)
    }
}

// get the data from an API,

// add item, have to send it to the api.



export interface TodoItem {
    id: string;
    description: string;
    completed: boolean;
}