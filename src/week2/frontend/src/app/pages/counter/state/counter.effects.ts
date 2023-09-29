import { Injectable } from "@angular/core";
import { Actions, concatLatestFrom, createEffect, ofType } from "@ngrx/effects";
import { map, tap } from "rxjs";
import { counterFeature } from ".";
import { CounterDocuments, CounterEvents } from "./counter.actions";
import { Store } from "@ngrx/store";

@Injectable({
    providedIn: 'root'
})
export class CounterEffects {

    loadCounterState$ = createEffect(() =>
        this.actions$.pipe(
            ofType(CounterEvents.counterEntered),
            map(() => {
                const savedItem = localStorage.getItem("counterState");
                if (savedItem !== null) {
                    const counterState = JSON.parse(savedItem);
                    if (counterState) {
                        return CounterDocuments.counterState({ payload: counterState });
                    }
                }
                return CounterEvents.resetClicked();
            }),
        ),
    );

    saveCounterState$ = createEffect(
        () =>
            this.actions$.pipe(
                ofType(
                    CounterEvents.incrementClicked,
                    CounterEvents.decrementClicked,
                    CounterEvents.resetClicked,
                    CounterEvents.countByChanged,
                ),
                concatLatestFrom(() =>
                    this.store.select(counterFeature.selectCounterState),
                ),
                map(([_, counterState]) => {
                    localStorage.setItem("counterState", JSON.stringify(counterState));
                }),
            ),
        { dispatch: false },
    );

    // logEmAll$ = createEffect(() => this.actions$.pipe(
    //     tap(action => console.log(`Got an action of the ${action.type}`))

    // ), { dispatch: false })

    constructor(private readonly actions$: Actions, private readonly store: Store) { }

} 