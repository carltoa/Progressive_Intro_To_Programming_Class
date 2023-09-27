import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { counterFeature } from './state';
import { CounterEvents } from './state/counter.actions';
import { PrefsComponent } from "./components/prefs/prefs.component";

@Component({
  selector: 'app-counter',
  standalone: true,
  template: `
   <div>
    <button (click)="decrement()" class="btn btn-circle btn-sm">-</button>
    <span>{{ current() }}</span>
    <button (click)="increment()" class="btn btn-circle btn-sm">+</button>
   </div>
   <div>
    <button (click)="reset()" [disabled]="resetDisabled()" class="btn btn-sm btn-accent">Reset</button>
</div>
<div>
  <app-prefs />
</div>
  `,
  styles: [],
  imports: [CommonModule, PrefsComponent]
})
export class CounterComponent {
  current = this.store.selectSignal(counterFeature.selectCurrent);
  resetDisabled = this.store.selectSignal(counterFeature.selectResetShouldBeDisabled);
  constructor(private readonly store: Store) { }
  increment() {
    this.store.dispatch(CounterEvents.incrementClicked());
  }

  decrement() {
    this.store.dispatch(CounterEvents.decrementClicked());
  }

  reset() {
    this.store.dispatch(CounterEvents.resetClicked());
  }
}
