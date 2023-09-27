import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PrimaryButtonDirective, SecondaryButtonDirective } from 'src/app/ui/primary-button.directive';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-todo-entry',
  standalone: true,
  imports: [CommonModule, PrimaryButtonDirective, SecondaryButtonDirective, ReactiveFormsModule],
  template: `

  <form [formGroup]="form" (ngSubmit)="addThisItem()">
          <label for="item">Item</label>
      <input type="text" class="input input-primary" id="item"  formControlName="item"/>
      <button type="submit" appSecondaryButton>Add Item</button>

  </form>
  `,
  styles: [
  ]
})
export class TodoEntryComponent {

  @Output() itemAdded = new EventEmitter<string>();

  form = new FormGroup({
    item: new FormControl<string>('', { nonNullable: true })
  })


  addThisItem() {
    const itemTheyWantToAdd = this.form.controls.item.value;
    this.itemAdded.emit(itemTheyWantToAdd);
    this.form.reset();
  }
}
