import { createActionGroup, emptyProps, props } from "@ngrx/store";
import { CounterState } from ".";


export type CountByValues = 1 | 3 | 5;
export const CounterEvents = createActionGroup({
    source: 'Counter Component Events',
    events: {
        'Increment Clicked': emptyProps(),
        'Decrement Clicked': emptyProps(),
        'Reset Clicked': emptyProps(),
        'Count By Changed': props<{ by: CountByValues }>(),
        'Counter Entered': emptyProps()
    }
})

export const CounterDocuments = createActionGroup({
    source: 'Counter Documents',
    events: {
        'Counter State': props<{ payload: CounterState }>()
    }
})