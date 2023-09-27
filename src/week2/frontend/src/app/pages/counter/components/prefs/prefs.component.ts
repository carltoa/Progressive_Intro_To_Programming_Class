import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Store } from '@ngrx/store';
import { CountByValues, CounterEvents } from '../../state/counter.actions';
import { counterFeature } from '../../state';

@Component({
  selector: 'app-prefs',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="join">
  <button [disabled]="by() === 1" (click)="setCountBy(1)" class="btn join-item">Count By 1</button>
  <button [disabled]="by() === 3" (click)="setCountBy(3)" class="btn join-item">Count By 3</button>
  <button [disabled]="by() === 5" (click)="setCountBy(5)" class="btn join-item">Count By 5</button>
</div>
  `,
  styles: [
  ]
})
export class PrefsComponent {
  store = inject(Store);
  by = this.store.selectSignal(counterFeature.selectBy);
  setCountBy(by: CountByValues) {
    this.store.dispatch(CounterEvents.countByChanged({ by }));
  }
}
