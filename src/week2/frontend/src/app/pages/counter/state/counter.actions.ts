import { createActionGroup, emptyProps, props } from "@ngrx/store";


export type CountByValues = 1 | 3 | 5;
export const CounterEvents = createActionGroup({
    source: 'Counter Component Events',
    events: {
        'Increment Clicked': emptyProps(),
        'Decrement Clicked': emptyProps(),
        'Reset Clicked': emptyProps(),
        'Count By Changed': props<{ by: CountByValues }>()
    }
})